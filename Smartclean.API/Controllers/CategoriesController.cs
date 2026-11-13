using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartclean.core.Interfaces;

namespace Smartclean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work) : base(work)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try 
            {
                var categories = await _work.CategoryRepositry.GetAllAsync();
                if(categories == null)
                
                    return BadRequest();
                return Ok(categories);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
