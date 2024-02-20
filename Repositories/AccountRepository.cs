using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AB_INVEST.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ABInvestContext _context;

        public AccountRepository(ABInvestContext context)
        {
            _context = context;
        }

        public AccountModel GetById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public AccountModel GetByUserId(int userId)
        {
            return _context.Accounts.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public AccountModel GetByKey(string key)
        {
            return _context.Accounts.Include(x => x.User).FirstOrDefault(x => x.AccountKey == key);
        }

        public AccountModel Create(AccountModel account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
        }

        public bool UpdateAccountKey(AccountModel account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();

            return true;
        }

        public bool AddToBalance(AccountModel account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();

            return true;
        }

        public bool RemoveFromBalance(AccountModel account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();

            return true;
        }
    }
}