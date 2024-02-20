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
        List<UserInvestmentModel> GetAll();
        UserInvestmentModel GetById(int id);
        List<UserInvestmentModel> GetByAccountId(int accountId);
        UserInvestmentModel Create(UserInvestmentDto userInvestmentDto);
        UserInvestmentModel AddBalance(int id, decimal value);
        UserInvestmentModel Update(int id, UserInvestmentModel userInvestmentModel);
        WithdrawModel WithDraw(int id, decimal? value);
    }
}