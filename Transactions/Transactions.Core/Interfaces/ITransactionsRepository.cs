using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Core.Models;

namespace Transactions.Core.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<bool> CreateNewTransaction(Transaction transaction);
        Task<List<Transaction>> GetTransactions(string accountNumber);
    }
}
