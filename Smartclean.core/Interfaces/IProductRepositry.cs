using Smartclean.core.DTO;
using Smartclean.core.Entities.Product;

namespace Smartclean.core.Interfaces
{
    public interface IProductRepositry:IGenericRepositry<Product>
    {
        Task<bool> AddAsync(AddProductDTO productDTO);
    }
}
