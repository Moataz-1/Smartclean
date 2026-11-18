using Microsoft.EntityFrameworkCore.Storage;
using Smartclean.core.Entities;
using Smartclean.core.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Smartclean.infrastructure.Repositories
{
    public class CustomerBasketRepositry : ICustomerBasketRepositry
    {
        private readonly StackExchange.Redis.IDatabase _database;

        public CustomerBasketRepositry(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public Task<bool> DeleteBasketAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerBasket> GetBasketAsync(string Id)
        {
            var result  = await _database.StringGetAsync(Id);
            if(!string.IsNullOrEmpty(result))
            {
                return JsonSerializer.Deserialize<CustomerBasket>(result);
            }
            return null;
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var _basket = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (_basket)
            {
                return await GetBasketAsync(basket.Id);
            }
            return null;
        }
    }
}
