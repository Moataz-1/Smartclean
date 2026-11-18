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
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {
            var result = await _work.Auth.RegisterAsync(registerDTO);
            if (result == "Registration successful")
            {
                return Ok(new ResponseAPI(200, result));
            }
            return BadRequest(new ResponseAPI(400, result));
        }
    }
}
