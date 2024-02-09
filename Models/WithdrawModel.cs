using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Models
{
    public class WithdrawModel
    {
        public int Id { get; set; }
        public decimal InitialValue { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public int InvestmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime WithdrawDate { get; set; }

        public AccountModel Account { get; set; }
        public InvestmentModel Investment { get; set; }
    }
}