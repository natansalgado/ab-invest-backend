using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Dtos
{
    public class UserInvestmentDto
    {
        public string Name { get; set; }
        public int AccountId { get; set; }
        public int InvestmentId { get; set; }
        public decimal InitialValue { get; set; }
    }
}