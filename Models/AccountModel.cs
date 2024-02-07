using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string AccountKey { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}