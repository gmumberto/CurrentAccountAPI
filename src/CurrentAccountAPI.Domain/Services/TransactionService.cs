using CurrentAccountAPI.Domain.DTOs;
using CurrentAccountAPI.Domain.Entity;
using CurrentAccountAPI.Domain.Entity.Validations;
using CurrentAccountAPI.Domain.Interface;
using CurrentAccountAPI.Domain.Interface.Repository;
using CurrentAccountAPI.Domain.Interface.Service;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentAccountAPI.Domain.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository, INotifier notifier) : base(notifier)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<Transaction>> Get(int customerId)
        {
            return await _transactionRepository.GetAllById(customerId);
        }

        public async Task Post(int customerId, decimal initialCredit, decimal customerAmountInAccount)
        {
            Transaction transaction = new Transaction()
            {
                customerID = customerId,
                transactionDate = DateTime.Now,
                transactionAmount = initialCredit,
                transactionReceivedFromAccount = 0,
                transactionSentToAccount = null,
                transactionRemainingBalance = customerAmountInAccount + initialCredit
            };

            if (!RunValidation(new TransactionValidation(), transaction)) return;

            await _transactionRepository.Add(transaction);
        }

        public void Dispose()
        {
            _transactionRepository?.Dispose();
        }
    }
}
