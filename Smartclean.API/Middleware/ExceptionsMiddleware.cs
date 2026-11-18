using Microsoft.Extensions.Caching.Memory;
using Smartclean.API.Helper;
using System.Net;
using System.Text.Json;

namespace Smartclean.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly IMemoryCache _memoryCash;
        private readonly TimeSpan _rateLimitWindow = TimeSpan.FromSeconds(30);
        public ExceptionsMiddleware(RequestDelegate next, IHostEnvironment environment, IMemoryCache memoryCash)
        {
            _next = next;
            _environment = environment;
            _memoryCash = memoryCash;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                ApplySecurity(context);

                if (IsRequestAllowed(context) == false) 
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var response = new ApiException((int)HttpStatusCode.TooManyRequests, "Too many Request. Pleas Try again later");
                    await context.Response.WriteAsJsonAsync(response);
                    return;
                }
                await _next(context);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                string details = ex.StackTrace ?? "";
                if (ex.InnerException != null)
                {
                    details = $"Inner: {ex.InnerException.Message}\r\n{ex.InnerException.StackTrace}\r\n{details}";
                }

                var response = _environment.IsDevelopment() ?
                    new ApiException((int)HttpStatusCode.InternalServerError,
                    ex.Message, details)
                    : new ApiException((int)HttpStatusCode.InternalServerError,
                    ex.Message);

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
        private bool IsRequestAllowed(HttpContext context) 
        {
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var cashkey = $"Rate: {ip}";
            var dateNow = DateTime.Now;

            var (timesTamp, count) = _memoryCash.GetOrCreate(cashkey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
                return (timesTamp: dateNow, count: 0);
            });
            if (dateNow - timesTamp < _rateLimitWindow)
            {
                if (count >= 8)
                {
                    return false;
                }
                _memoryCash.Set(cashkey, (timesTamp, count += 1), _rateLimitWindow);
            }
            else
            {
                _memoryCash.Set(cashkey, (timesTamp, count), _rateLimitWindow);
            }
            return true;
        }

        private void ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type.Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1;mode=block";
            context.Response.Headers["X-Frame-Options"] = "DENY";
        }
    }
}
