using Evented.Domain.Contracts;
using Evented.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Evented.Domain.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            _db.Set<T>().Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T item)
        {

            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task AddBulkAsync(List<T> items)
        {
            await _db.AddRangeAsync(items);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var item = await GetAsync(id);
            return item != null;
        }

        public async Task UpdateAsync(T item)
        {

            _db.Update(item);
            await _db.SaveChangesAsync();
        }
        public async Task<List<T>> ReadConditionally(Expression<Func<T, bool>> condition)
        {
            return await _db.Set<T>().Where(condition).ToListAsync();
        }
    }
}
