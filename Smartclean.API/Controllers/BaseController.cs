using AutoMapper;
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
        protected readonly IMapper _mapper;
        public BaseController(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }
    }
}
