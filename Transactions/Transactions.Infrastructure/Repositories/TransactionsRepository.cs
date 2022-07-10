using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Core.Interfaces;
using Transactions.Core.Models;

namespace Transactions.Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly AppDBContext _appDbContext;

        public TransactionsRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> CreateNewTransaction(Transaction transaction)
        {
            var outPut = await _appDbContext.AddAsync<Transaction>(transaction);
            await _appDbContext.SaveChangesAsync();
            return outPut != null ? true : false;
        }

        public async Task<List<Transaction>> GetTransactions(string accountNumber)
        {           
            var trans = await _appDbContext.Transaction.Where(t=>t.AccountNumber== accountNumber).ToListAsync();
            return trans;
        }
    }
}
