using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Infrastructure.Repositories
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;
        private readonly DbSet<T> _dbSet;

        public DataRepository(OrderContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _dbSet.FindAsync(id);
            return value!;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var value = await _dbSet.FirstOrDefaultAsync(filter);
            return value!;
        }
    }
}
