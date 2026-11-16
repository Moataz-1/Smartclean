using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartclean.API.Helper;
using Smartclean.core.DTO;
using Smartclean.core.Interfaces;

namespace Smartclean.API.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var Product = await _work.ProductRepositry
                    .GetAllAsync(x => x.Category, x => x.Photos);
                var result = _mapper.Map<List<ProductDTO>>(Product);
                if (Product is null) 
                {
                    return BadRequest(new ResponseAPI(400));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var product = await _work.ProductRepositry.GetByIdAsync(id,
                    x => x.Category, x => x.Photos);
                var result = _mapper.Map<ProductDTO>(product);
                if(product is null)
                {
                    return BadRequest(new ResponseAPI(400));

                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> add(AddProductDTO productDTO)
        {
            try
            {
                await _work.ProductRepositry.AddAsync(productDTO);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
