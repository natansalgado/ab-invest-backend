using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IUserInvestmentRepository
    {
        List<UserInvestmentModel> FindAll();
        UserInvestmentModel FindById(int id);
        List<UserInvestmentModel> FindByAccountId(int accountId);
        UserInvestmentModel CreateUserInvestment(UserInvestmentModel userInvestment);
        WithdrawModel CreateWithdraw(WithdrawModel withdrawModel);
        void Delete(UserInvestmentModel userInvestment);
    }
}