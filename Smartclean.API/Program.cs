using Smartclean.infrastructure;
using Microsoft.Extensions.FileProviders;
using Smartclean.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(op => 
{
    op.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https //localhost:4200");
    });
});

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddSingleton<IFileProvider>(builder.Environment.WebRootFileProvider);
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(_ => { }, AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSPolicy");

app.UseMiddleware<ExceptionsMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
