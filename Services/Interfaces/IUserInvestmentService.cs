using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;

namespace AB_INVEST.Services.Interfaces
{
    public interface IUserInvestmentService
    {
        List<UserInvestmentModel> FindAll();
        UserInvestmentModel FindById(int id);
        List<UserInvestmentModel> FindByAccountId(int accountId);
        UserInvestmentModel Create(UserInvestmentDto userInvestmentDto);
        WithdrawModel WithDraw(int id);
    }
}