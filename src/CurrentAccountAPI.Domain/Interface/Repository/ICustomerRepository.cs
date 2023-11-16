using CurrentAccountAPI.Domain.DTOs;
using CurrentAccountAPI.Domain.Entity;

namespace CurrentAccountAPI.Domain.Interface.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetByIdAllClass(int customerId);
    }
}
