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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepository repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        public TransferConfirmDto CheckAccountToTransfer(TransferDto transferDto)
        {
            if (transferDto.Value <= 0)
                throw new ABException(400, "Valor de transferência inválido");

            AccountModel account = _accountService.FindByKey(transferDto.ReceiverKey) ??
                throw new ABException(404, "Conta de destino não encontrada");

            return new TransferConfirmDto()
            {
                ReceiverName = account.User.Name,
                ReceiverKey = account.AccountKey,
                Value = transferDto.Value,
            };
        }

        public TransferDoneDto Transfer(TransferDto transferDto)
        {
            string senderKey = transferDto.SenderKey;
            string receiverKey = transferDto.ReceiverKey;
            decimal value = transferDto.Value;

            ValidateTransferInputs(senderKey, receiverKey, value);

            AccountModel senderAccount = _accountService.FindByKey(senderKey);
            AccountModel receiverAccount = _accountService.FindByKey(receiverKey);

            ValidateAccounts(senderAccount, receiverAccount, value);

            PerformTransfer(senderAccount, receiverAccount, value);

            TransferModel transfer = new()
            {
                SenderAccount = senderAccount,
                ReceiverAccount = receiverAccount,
                Value = value,
                Date = DateTime.Now
            };

            TransferModel transferDone = _repository.Transfer(transfer);

            return CreateTransferDoneDto(transferDone);
        }

        private static TransferDoneDto CreateTransferDoneDto(TransferModel transfer)
        {
            return new TransferDoneDto()
            {
                ReceiverName = transfer.ReceiverAccount.User.Name,
                ReceiverKey = transfer.ReceiverAccount.AccountKey,
                SenderName = transfer.SenderAccount.User.Name,
                SenderKey = transfer.SenderAccount.AccountKey,
                Date = transfer.Date,
                Value = transfer.Value
            };
        }

        private static void ValidateTransferInputs(string senderKey, string receiverKey, decimal value)
        {
            if (value <= 0)
                throw new ABException(400, "Valor de transferência inválido");

            if (string.IsNullOrEmpty(senderKey))
                throw new ABException(400, "Chave da sua conta inválida");

            if (string.IsNullOrEmpty(receiverKey))
                throw new ABException(400, "Chave da conta de destino inválida");

            if (senderKey == receiverKey)
                throw new ABException(409, "Não é possível fazer uma transferência a si mesmo");
        }

        private static void ValidateAccounts(AccountModel senderAccount, AccountModel receiverAccount, decimal value)
        {
            if (senderAccount == null)
                throw new ABException(404, "Erro ao tentar acessar sua conta");

            if (receiverAccount == null)
                throw new ABException(403, "Erro ao tentar encontrar a conta de destino");

            if (senderAccount.Balance < value)
                throw new ABException(404, "Saldo insuficiente");
        }

        private void PerformTransfer(AccountModel senderAccount, AccountModel receiverAccount, decimal value)
        {
            _accountService.RemoveFromBalance(senderAccount.Id, value);
            _accountService.AddToBalance(receiverAccount.Id, value);
        }
    }
}