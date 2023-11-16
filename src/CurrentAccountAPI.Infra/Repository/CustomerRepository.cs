using CurrentAccountAPI.Domain.DTOs;
using CurrentAccountAPI.Domain.Entity;
using CurrentAccountAPI.Domain.Interface.Repository;
using CurrentAccountAPI.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace CurrentAccountAPI.Infra.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContextClass context) : base(context) { }

        public async Task<Customer> GetByIdAllClass(int customerId)
        {
            return await _dbContext.customer.FirstOrDefaultAsync(c => c.customerID == customerId);
        }
    }
}
