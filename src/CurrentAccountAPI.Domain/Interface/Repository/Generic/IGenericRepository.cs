using System.Linq.Expressions;

namespace CurrentAccountAPI.Domain.Interface.Repository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task<int> SaveChanges();
    }
}