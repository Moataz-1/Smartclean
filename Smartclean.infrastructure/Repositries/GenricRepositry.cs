using Smartclean.core.Interfaces;
using System.Linq.Expressions;

namespace Smartclean.infrastructure.Repositries
{
    internal class GenricRepositry<T> : IGenericRepositry<T> where T : class
    {
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}