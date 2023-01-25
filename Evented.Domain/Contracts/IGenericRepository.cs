using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evented.Domain.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task AddBulkAsync(List<T> items);
        Task<bool> Exists(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T item);
        //Task<T> FindBasedTwoCond(Expression<Func<T, T>> condition);

    }
}
