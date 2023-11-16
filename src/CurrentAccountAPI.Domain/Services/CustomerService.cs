using CurrentAccountAPI.Domain.DTOs;
using CurrentAccountAPI.Domain.Entity;
using CurrentAccountAPI.Domain.Entity.Validations;
using CurrentAccountAPI.Domain.Interface;
using CurrentAccountAPI.Domain.Interface.Repository;
using CurrentAccountAPI.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace CurrentAccountAPI.Domain.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionService _transactionService;

        public CustomerService(ICustomerRepository costumerRepository, INotifier notifier) : base(notifier)
        {
            _customerRepository = costumerRepository;
        }

        public async Task<Customer> GetByIdAllClass(int customerId)
        {
            return await _customerRepository.GetByIdAllClass(customerId);
        }

        public async Task<Customer> Get(int customerId)
        {
            return await _customerRepository.GetById(customerId);
        }

        public async Task PostIfUserNotExists(int customerId, decimal initialCredit)
        {
            var result = Get(customerId);

            if (result != null)
            {
                return;
            }

            Customer customer = new Customer()
            {
                customerName = "NameTest " + customerId.ToString(),
                customerSurename = "SurenameTest " + customerId.ToString(),
                customerAmountInAccount = 0 + customerId,
                customerCredit = initialCredit,
                customerAccount = 1 + customerId
            };

            if (!RunValidation(new CustomerValidation(), customer)) return;

            await _customerRepository.Add(customer);
            await _transactionService.Post(customerId, initialCredit, result.Result.customerAmountInAccount);
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}
