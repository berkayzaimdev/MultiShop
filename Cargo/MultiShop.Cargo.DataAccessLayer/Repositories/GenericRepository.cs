using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CargoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var value = _dbSet.Find(entity);
            _dbSet.Remove(value);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            var value = _dbSet.Find(id);
            return value;
        }

        public IEnumerable<T> GetAll()
        {
            var values = _dbSet.AsEnumerable();
            return values;
        }
    }
}
