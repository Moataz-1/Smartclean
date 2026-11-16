using Smartclean.core.DTO;
using Smartclean.core.Entities.Product;
using Smartclean.core.Sharing;

namespace Smartclean.core.Interfaces
{
    public interface IProductRepositry:IGenericRepositry<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(AddProductDTO productDTO);
        Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task DeleteAsync(Product product);
    }
}
