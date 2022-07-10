using Account.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> AddAccount(Accounts accounts);
        Task<Accounts> GetAccount(string accountNumber);

        Task<List<Accounts>> GetAllAccounts();
    }

}
