using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Dtos
{
    public class TransferDoneDto
    {
        public string SenderName { get; set; }
        public string SenderKey { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverKey { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}