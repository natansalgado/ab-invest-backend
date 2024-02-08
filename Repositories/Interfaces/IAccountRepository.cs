using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        AccountModel Create(AccountModel account);
        AccountModel FindById(int id);
        AccountModel FindByKey(string key);
        bool AddToBalance(int id, decimal value);
        bool RemoveFromBalance(int id, decimal value);
        bool UpdateAccountKey(int id, string key);
    }
}