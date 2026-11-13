using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartclean.core.Interfaces;

namespace Smartclean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _work;
        public BaseController(IUnitOfWork work)
        {
            _work = work;
        }
    }
}
