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

        public AccountModel FindById(int id)
        {
            return _repository.FindById(id);
        }

        public AccountModel FindByUserId(int userId)
        {
            return _repository.FindByUserId(userId);
        }

        public AccountModel FindByKey(string key)
        {
            return _repository.FindByKey(key);
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
            AccountModel accountExists = _repository.FindById(id);

            if (accountExists == null)
                return false;

            return _repository.UpdateAccountKey(id, key);
        }

        public bool AddToBalance(int id, decimal value)
        {
            return _repository.AddToBalance(id, value);
        }

        public bool RemoveFromBalance(int id, decimal value)
        {
            return _repository.RemoveFromBalance(id, value);
        }
    }
}