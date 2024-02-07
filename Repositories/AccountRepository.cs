using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;

namespace AB_INVEST.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ABInvestContext _context;

        public AccountRepository(ABInvestContext context)
        {
            _context = context;
        }

        public AccountModel FindById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public AccountModel FindByKey(string key)
        {
            return _context.Accounts.Where(x => x.AccountKey == key).FirstOrDefault();
        }

        public AccountModel Create(AccountModel account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
        }

        public bool UpdateAccountKey(int id, string key)
        {
            AccountModel account = FindById(id);

            account.AccountKey = key;

            _context.Accounts.Update(account);
            _context.SaveChanges();

            return true;
        }
    }
}