using CurrentAccountAPI.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CurrentAccountAPI.Domain.Interface.Service
{
    public interface ICustomerService : IDisposable
    {
        Task<Customer> Get(int customerId);
        Task<Customer> GetByIdAllClass(int customerId);
        Task PostIfUserNotExists(int customerId, decimal initialCredit);
    }
}
