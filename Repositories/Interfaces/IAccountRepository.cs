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
        AccountModel FindByUserId(int userId);
        bool AddToBalance(AccountModel account);
        bool RemoveFromBalance(AccountModel account);
        bool UpdateAccountKey(AccountModel account);
    }
}