using Microsoft.EntityFrameworkCore;
using StoreProject.Data.Interface;
using StoreProject.Model;
using System.Linq.Expressions;

namespace StoreProject.Data
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task Add(T entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            _dbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }
    }
}
