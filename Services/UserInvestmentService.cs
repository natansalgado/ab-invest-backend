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

        public UserInvestmentService(IUserInvestmentRepository repository, IAccountService accountService, IInvestmentService investmentService)
        {
            _repository = repository;
            _accountService = accountService;
            _investmentService = investmentService;
        }

        public List<UserInvestmentModel> GetAll()
        {
            return _repository.GetAll();
        }

        public UserInvestmentModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<UserInvestmentModel> GetByAccountId(int accountId)
        {
            AccountModel account = _accountService.GetById(accountId);

            if (account == null)
                return null;

            return _repository.GetByAccountId(accountId);
        }

        public UserInvestmentModel Create(UserInvestmentDto userInvestmentDto)
        {
            AccountModel account = _accountService.GetById(userInvestmentDto.AccountId);
            InvestmentModel investment = _investmentService.GetById(userInvestmentDto.InvestmentId);

            CheckCreate(account, investment, userInvestmentDto);

            _accountService.RemoveFromBalance(account.Id, userInvestmentDto.InitialValue);

            UserInvestmentModel userInvestment = ConvertToUserInvestmentModel(userInvestmentDto);
            userInvestment.Balance = userInvestment.InitialValue;
            userInvestment.StartDate = DateTime.Now;
            userInvestment.EndDate = DateTime.Now.AddMonths(investment.MinMonths);

            return _repository.CreateUserInvestment(userInvestment);
        }

        public UserInvestmentModel AddBalance(int id, decimal value)
        {
            UserInvestmentModel userInvestment = GetById(id)
                ?? throw new ABException(404, "Não foi possível encontrar seu investimento");
            
            AccountModel account = _accountService.GetById(userInvestment.AccountId)
                ?? throw new ABException(404, "Não foi possível encontrar sua conta bancária");
            
            if (account.Balance < value) throw new ABException(400, "Saldo insuficiente");

            _accountService.RemoveFromBalance(userInvestment.AccountId, value);

            userInvestment.AddedValue += value;
            userInvestment.Balance += value;

            return _repository.Update(userInvestment);
        }

        public UserInvestmentModel Update(int id, UserInvestmentModel userInvestment)
        {
            UserInvestmentModel userInvestmentById = GetById(id);

            if (userInvestmentById == null)
                return null;

            if (userInvestment.Balance > 0) userInvestmentById.Balance = userInvestment.Balance;

            return _repository.Update(userInvestmentById);
        }

        public WithdrawModel WithDraw(int id, decimal value)
        {
            UserInvestmentModel userInvestment = GetById(id);

            CheckWithDraw(userInvestment);

            WithdrawModel withdrawModel = ConvertToWithdraw(userInvestment, value);

            WithdrawModel withdraw = _repository.CreateWithdraw(withdrawModel);

            _accountService.AddToBalance(userInvestment.AccountId, userInvestment.Balance);

            CheckIfDeleteUserInvestment(withdraw, userInvestment);

            return withdraw;
        }

        private void CheckCreate(AccountModel account,
                                        InvestmentModel investment,
                                        UserInvestmentDto userInvestmentDto)
        {
            List<UserInvestmentModel> userInvestments = _repository.GetByAccountId(account.Id);
            UserInvestmentModel reapetedUserInvestment = userInvestments.Find(x => x.Name == userInvestmentDto.Name);

            if (reapetedUserInvestment != null)
                throw new ABException(409, "Você já usou esse nome em outro investimento");

            if (account == null)
                throw new ABException(404, "Conta não encontrada");

            if (investment == null)
                throw new ABException(404, "Investimento não encontrado");

            if (userInvestmentDto.InitialValue < investment.MinValue)
                throw new ABException(400, $"O depósito inicial deve ser de no mínimo R$ {investment.MinValue:00.00}");

            if (account.Balance < userInvestmentDto.InitialValue)
                throw new ABException(400, "Saldo insuficiente");
        }

        private void CheckWithDraw(UserInvestmentModel userInvestment)
        {
            AccountModel account = _accountService.GetById(userInvestment.AccountId);

            if (account == null)
                throw new ABException(404, "Conta não encontrada");

            if (userInvestment == null)
                throw new ABException(404, "Investimento do usuário não encontrado");

            if (DateTime.Now < userInvestment.EndDate)
                throw new ABException(400, "Não é possível fazer o saque ainda");
        }

        private static UserInvestmentModel ConvertToUserInvestmentModel(UserInvestmentDto userInvestmentDto)
        {
            return new UserInvestmentModel()
            {
                Name = userInvestmentDto.Name,
                AccountId = userInvestmentDto.AccountId,
                InvestmentId = userInvestmentDto.InvestmentId,
                InitialValue = userInvestmentDto.InitialValue
            };
        }

        private static WithdrawModel ConvertToWithdraw(UserInvestmentModel userInvestment, decimal withdreValue)
        {
            return new WithdrawModel()
            {
                AccountId = userInvestment.AccountId,
                InvestmentId = userInvestment.InvestmentId,
                InitialValue = userInvestment.InitialValue,
                Balance = userInvestment.Balance,
                WithdrewValue = withdreValue,
                StartDate = userInvestment.StartDate,
                EndDate = userInvestment.EndDate,
                WithdrawDate = DateTime.Now
            };
        }

        private void CheckIfDeleteUserInvestment(WithdrawModel withdraw, UserInvestmentModel userInvestment)
        {
            if (withdraw.Balance == withdraw.WithdrewValue || withdraw.Balance - withdraw.WithdrewValue <= 0)
            {
                _repository.Delete(userInvestment);
            }
        }
    }
}