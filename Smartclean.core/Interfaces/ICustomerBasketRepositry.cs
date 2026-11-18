using Smartclean.core.Entities;

namespace Smartclean.core.Interfaces
{
    public interface ICustomerBasketRepositry
    {
        Task<CustomerBasket> GetBasketAsync(string Id);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string Id);
    }
}
