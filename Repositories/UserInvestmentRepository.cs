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
    public class UserInvestmentRepository : IUserInvestmentRepository
    {
        private readonly ABInvestContext _context;

        public UserInvestmentRepository(ABInvestContext context)
        {
            _context = context;
        }

        public List<UserInvestmentModel> FindAll()
        {
            return _context.UsersInvestments.Include(x => x.Investment).ToList();
        }

        public UserInvestmentModel FindById(int id)
        {
            return _context.UsersInvestments.Find(id);
        }

        public List<UserInvestmentModel> FindByAccountId(int accountId)
        {
            return _context.UsersInvestments.Where(x => x.AccountId == accountId)
                .OrderByDescending(x => x.StartDate).Include(x => x.Investment).ToList();
        }

        public UserInvestmentModel CreateUserInvestment(UserInvestmentModel userInvestment)
        {
            _context.UsersInvestments.Add(userInvestment);
            _context.SaveChanges();

            return userInvestment;
        }

        public WithdrawModel CreateWithdraw(WithdrawModel withdrawModel)
        {
            _context.Withdraws.Add(withdrawModel);
            _context.SaveChanges();

            return withdrawModel;
        }

        public UserInvestmentModel Update(UserInvestmentModel userInvestment)
        {
            _context.UsersInvestments.Update(userInvestment);
            _context.SaveChanges();

            return userInvestment;
        }

        public void Delete(UserInvestmentModel userInvestment)
        {
            _context.UsersInvestments.Remove(userInvestment);
            _context.SaveChanges();
        }
    }
}