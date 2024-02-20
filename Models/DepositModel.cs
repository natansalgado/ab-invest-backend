using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Models
{
    public class DepositModel : TransactionModel
    {
        public string PaymentMethod { get; set; }
        public int AccountId { get; set; }

        public AccountModel Account { get; set; }
    }
}