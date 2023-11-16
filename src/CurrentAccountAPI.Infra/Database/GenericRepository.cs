using System.Linq.Expressions;
using CurrentAccountAPI.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace CurrentAccountAPI.Infra.Database
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContextClass _dbContext;
        protected readonly DbSet<T> DbSet;

        protected GenericRepository(DbContextClass context)
        {
            _dbContext = context;
            DbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}

