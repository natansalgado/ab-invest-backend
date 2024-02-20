using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;

namespace AB_INVEST.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ABInvestContext _context;

        public TransactionRepository(ABInvestContext context)
        {
            _context = context;
        }

        public TransferModel Transfer(TransferModel transfer)
        {
            _context.Transfers.Add(transfer);
            _context.SaveChanges();
            
            return transfer;
        }

        public DepositModel Deposit(DepositModel deposit)
        {
            _context.Deposits.Add(deposit);
            _context.SaveChanges();

            return deposit;
        }
    }
}