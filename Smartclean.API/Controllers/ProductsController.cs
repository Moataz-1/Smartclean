using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smartclean.API.Helper;
using Smartclean.core.DTO;
using Smartclean.core.Interfaces;
using Smartclean.core.Services;
using Smartclean.core.Sharing;

namespace Smartclean.API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IImageManagementService imageManagementService;
        public ProductsController(IUnitOfWork work, IMapper mapper, IImageManagementService imageManagementService) : base(work, mapper)
        {
            this.imageManagementService = imageManagementService;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> get([FromQuery]ProductParams productParams)
        {
            try
            {

                var Product = await _work.ProductRepositry
                    .GetAllAsync(productParams);

                var totalCount = await _work.ProductRepositry.CountAsync();
                return Ok(new Pagination<ProductDTO>(productParams.PageNumber, productParams.pageSize, totalCount, Product));
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
                return Ok( new ResponseAPI (200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpPut ("update-product")]
        public async Task<IActionResult> Update(UpdateProductDTO updateProductDTO)
        {
            try
            {
                await _work.ProductRepositry.UpdateAsync(updateProductDTO);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var product = await _work.ProductRepositry
                    .GetByIdAsync(id, x => x.Photos, x => x.Category);
                await _work.ProductRepositry.DeleteAsync(product);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
