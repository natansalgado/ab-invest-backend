using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Exceptions;
using AB_INVEST.Models;
using AB_INVEST.Services.Interfaces;
using Quartz;

namespace AB_INVEST.Jobs
{
    public class CheckUsersInvestments : IJob
    {
        private readonly IUserInvestmentService _userInvestmentService;

        public CheckUsersInvestments(IUserInvestmentService userInvestmentService)
        {
            _userInvestmentService = userInvestmentService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            List<UserInvestmentModel> usersInvestments = _userInvestmentService.FindAll();

            foreach (var userInvestment in usersInvestments)
            {
                decimal percentage = userInvestment.Investment.AnnualPercentage / 365;

                decimal decimalPercentage = percentage / 100;

                userInvestment.Balance += userInvestment.Balance * decimalPercentage;
                
                _userInvestmentService.Update(userInvestment.Id, userInvestment);
            }

            return Task.FromResult(true);
        }
    }
}