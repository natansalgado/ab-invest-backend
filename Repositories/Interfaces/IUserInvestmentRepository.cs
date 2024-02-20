using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IUserInvestmentRepository
    {
        List<UserInvestmentModel> GetAll();
        UserInvestmentModel GetById(int id);
        List<UserInvestmentModel> GetByAccountId(int accountId);
        UserInvestmentModel CreateUserInvestment(UserInvestmentModel userInvestment);
        WithdrawModel CreateWithdraw(WithdrawModel withdrawModel);
        UserInvestmentModel Update(UserInvestmentModel userInvestment);
        void Delete(UserInvestmentModel userInvestment);
    }
}