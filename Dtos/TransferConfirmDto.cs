using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Dtos
{
    public class TransferConfirmDto
    {
        public string ReceiverName { get; set; }
        public string ReceiverKey { get; set; }
        public decimal Value { get; set; }
    }
}