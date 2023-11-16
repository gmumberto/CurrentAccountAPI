using CurrentAccountAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentAccountAPI.Domain.Interface.Service
{
    public interface ITransactionService : IDisposable
    {
        Task<List<Transaction>> Get(int customerId);
        Task Post(int customerId, decimal initialCredit, decimal customerAmountInAccount);
    }
}
