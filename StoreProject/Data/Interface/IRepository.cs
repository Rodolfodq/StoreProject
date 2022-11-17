using StoreProject.Model;
using System.Linq.Expressions;

namespace StoreProject.Data.Interface
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Add(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Remove(int id);
        IQueryable<T> Search(Expression<Func<T, bool>> where);
        Task<int> SaveChanges();
    }
}
