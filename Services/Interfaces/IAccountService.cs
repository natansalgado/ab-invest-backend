using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Services.Interfaces
{
    public interface IAccountService
    {
        AccountModel FindByKey(string key);
        void Create(int userId);
        bool UpdateAccountKey(int id, string key);
        bool AddToBalance(int id, decimal value);
        bool RemoveFromBalance(int id, decimal value);
    }
}