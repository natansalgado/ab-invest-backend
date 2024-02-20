using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using AB_INVEST.Services.Interfaces;

namespace AB_INVEST.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public AccountModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public AccountModel GetByUserId(int userId)
        {
            return _repository.GetByUserId(userId);
        }

        public AccountModel GetByKey(string key)
        {
            return _repository.GetByKey(key);
        }

        public void Create(int userId)
        {
            AccountModel account = new()
            {
                UserId = userId,
                AccountKey = Guid.NewGuid().ToString()
            };

            _repository.Create(account);
        }

        public bool UpdateAccountKey(int id, string key)
        {
            AccountModel account = GetById(id);

            account.AccountKey = key;

            if (account == null) return false;

            return _repository.UpdateAccountKey(account);
        }

        public bool AddToBalance(int id, decimal value)
        {
            AccountModel account = GetById(id);

            if (account == null) return false;

            account.Balance += value;

            return _repository.AddToBalance(account);
        }

        public bool RemoveFromBalance(int id, decimal value)
        {
            AccountModel account = GetById(id);

            if (account == null) return false;

            account.Balance -= value;

            return _repository.RemoveFromBalance(account);
        }
    }
}