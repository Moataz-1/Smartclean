using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartclean.API.Helper;
using Smartclean.core.DTO;
using Smartclean.core.Entities.Product;
using Smartclean.core.Interfaces;

namespace Smartclean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : BaseController
    {
        public CategorysController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var categories = await _work.CategoryRepositry.GetAllAsync();
                if (categories == null)

                    return BadRequest(new ResponseAPI(400));
                return Ok(categories);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getbyId(int id)
        {
            try
            {
                var category = await _work.CategoryRepositry.GetByIdAsync(id);
                if (category == null)
                    return BadRequest(new ResponseAPI(400,$"not found category id = {id}"));
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> add(CategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                await _work.CategoryRepositry.AddAsync(category);
                return Ok(new ResponseAPI(200, "Item has been added"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> update(UpdateCategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);
                await _work.CategoryRepositry.UpdateAsync(category);
                return Ok(new ResponseAPI(200, "Item has been updated"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                await _work.CategoryRepositry.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been deleted"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
