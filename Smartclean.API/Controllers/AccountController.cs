using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smartclean.API.Helper;
using Smartclean.core.DTO;
using Smartclean.core.Interfaces;

namespace Smartclean.API.Controllers
{

    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var result = await _work.Auth.RegisterAsync(registerDTO);
            if (result == "Registration successful")
            {
                return Ok(new ResponseAPI(200, result));
            }
            return BadRequest(new ResponseAPI(400, result));
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDTO loginDTO)
        {
            var result = await _work.Auth.LoginAsync(loginDTO);
            if (result.StartsWith("please"))
            {
                return BadRequest(new ResponseAPI(400, result));
            }

            Response.Cookies.Append("token", result, new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                Domain = "localhost",
                Expires = DateTime.Now.AddDays(1),
                IsEssential = true,
                SameSite = SameSiteMode.Strict,
            });
            return Ok(new ResponseAPI(200));
        }

        [HttpPost("avtive-Account")]
        public async Task<IActionResult> active(ActiveAcountDTO accountDTO)
        {
            var result = await _work.Auth.ActiveAccount(accountDTO);
            return result ? Ok(new ResponseAPI(200)) : BadRequest(new ResponseAPI(400));
        }

        [HttpGet("send-email-forget-password")]
        public async Task<IActionResult> forget(string email)
        {
            var result = await _work.Auth.SendEmailForForgetPassword(email);
            return result ? Ok(new ResponseAPI(200)) : BadRequest(new ResponseAPI(400));
        }

    }
}
