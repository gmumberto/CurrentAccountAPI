using CurrentAccountAPI.Domain.Entity;
using CurrentAccountAPI.Domain.Interface.Repository;
using CurrentAccountAPI.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace CurrentAccountAPI.Infra.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContextClass context) : base(context) { }

        public async Task<List<Transaction>> GetAllById(int customerId)
        {
            return await _dbContext.transaction.Where(x => x.customerID == customerId).ToListAsync();
        }
    }
}