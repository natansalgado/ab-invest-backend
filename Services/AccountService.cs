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

        public AccountModel FindByKey(string key)
        {
            return _repository.FindByKey(key);
        }

        public bool UpdateAccountKey(int id, string key)
        {
            AccountModel accountExists = _repository.FindById(id);

            if (accountExists == null)
                return false;

            return _repository.UpdateAccountKey(id, key);
        }
    }
}