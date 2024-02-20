using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Dtos
{
    public class DepositDto
    {
        public decimal Value { get; set; }
        public int AccountId { get; set; }
        public string PaymentMethod { get; set; }
    }
}