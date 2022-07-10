using Account.Core.Interfaces;
using Account.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDBContext appDbContext;

        public AccountRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAccount(Accounts account)
        {            
            var outPut = await appDbContext.AddAsync<Accounts>(account);
            await appDbContext.SaveChangesAsync();
            return outPut != null ? true : false;
        }

        public async Task<Accounts> GetAccount(string accountNumber)
        {
            //Accounts account = new Accounts();
            Accounts account =  await appDbContext.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefaultAsync();
            return account;
        }

        public async Task<List<Accounts>> GetAllAccounts()
        {
            List<Accounts> accounts = null;
            accounts = await appDbContext.Accounts.ToListAsync();
            return accounts;
        }

    }
}
