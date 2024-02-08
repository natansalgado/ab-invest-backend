using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Models
{
    public class TransferModel : TransactionModel
    {
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }

        public AccountModel SenderAccount { get; set; }
        public AccountModel ReceiverAccount { get; set; }
    }
}