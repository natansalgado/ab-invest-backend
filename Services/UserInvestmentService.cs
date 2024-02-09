using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Exceptions;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using AB_INVEST.Services.Interfaces;

namespace AB_INVEST.Services
{
    public class UserInvestmentService : IUserInvestmentService
    {
        private readonly IUserInvestmentRepository _repository;
        private readonly IAccountService _accountService;
        private readonly IInvestmentService _investmentService;

        public UserInvestmentService(IUserInvestmentRepository repository,
                                     IAccountService accountService,
                                     IInvestmentService investmentService)
        {
            _repository = repository;
            _accountService = accountService;
            _investmentService = investmentService;
        }

        public List<UserInvestmentModel> FindAll()
        {
            return _repository.FindAll();
        }

        public UserInvestmentModel FindById(int id)
        {
            return _repository.FindById(id);
        }

        public List<UserInvestmentModel> FindByAccountId(int accountId)
        {
            AccountModel account = _accountService.FindById(accountId);

            if (account == null)
                return null;

            return _repository.FindByAccountId(accountId);
        }

        public UserInvestmentModel Create(UserInvestmentDto userInvestmentDto)
        {
            AccountModel account = _accountService.FindById(userInvestmentDto.AccountId);
            InvestmentModel investment = _investmentService.FindById(userInvestmentDto.InvestmentId);

            CheckCreate(account, investment, userInvestmentDto);

            _accountService.RemoveFromBalance(account.Id, userInvestmentDto.InitialValue);

            UserInvestmentModel userInvestment = ConvertToUserInvestmentModel(userInvestmentDto);
            userInvestment.Balance = userInvestment.InitialValue;
            userInvestment.StartDate = DateTime.Now;
            userInvestment.EndDate = DateTime.Now.AddMonths(investment.MinMonths);

            return _repository.CreateUserInvestment(userInvestment);
        }

        public WithdrawModel WithDraw(int id)
        {
            UserInvestmentModel userInvestment = FindById(id);

            CheckWithDraw(userInvestment);

            WithdrawModel withdrawModel = ConvertToWithdraw(userInvestment);

            WithdrawModel withdraw = _repository.CreateWithdraw(withdrawModel);

            _repository.Delete(userInvestment);

            return withdraw;
        }

        private static void CheckCreate(AccountModel account,
                                        InvestmentModel investment,
                                        UserInvestmentDto userInvestmentDto)
        {
            if (account == null)
                throw new ABException(404, "Conta não encontrada");

            if (investment == null)
                throw new ABException(404, "Investimento não encontrado");

            if (userInvestmentDto.InitialValue < investment.MinValue)
                throw new ABException(400, $"O depósito inicial deve ser de no mínimo R$ {investment.MinValue:00.00}");

            if (account.Balance < userInvestmentDto.InitialValue)
                throw new ABException(400, "Saldo insuficiente");
        }

        private static void CheckWithDraw(UserInvestmentModel userInvestment)
        {
            if (userInvestment == null)
                throw new ABException(404, "Investimento do usuário não encontrado");

            if (DateTime.Now < userInvestment.EndDate)
                throw new ABException(400, "Não é possível fazer o saque ainda");
        }

        private static UserInvestmentModel ConvertToUserInvestmentModel(UserInvestmentDto userInvestmentDto)
        {
            return new UserInvestmentModel()
            {
                AccountId = userInvestmentDto.AccountId,
                InvestmentId = userInvestmentDto.InvestmentId,
                InitialValue = userInvestmentDto.InitialValue
            };
        }

        private static WithdrawModel ConvertToWithdraw(UserInvestmentModel userInvestment)
        {
            return new WithdrawModel()
            {
                AccountId = userInvestment.AccountId,
                InvestmentId = userInvestment.InvestmentId,
                InitialValue = userInvestment.InitialValue,
                Balance = userInvestment.Balance,
                StartDate = userInvestment.StartDate,
                EndDate = userInvestment.EndDate,
                WithdrawDate = DateTime.Now
            };
        }
    }
}