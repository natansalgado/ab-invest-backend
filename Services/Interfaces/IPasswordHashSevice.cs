using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_INVEST.Services.Interfaces
{
    public interface IPasswordHashSevice
    {
        string HashPassword(string password);
        bool VerifyPassword(string providedPassword, string hashedPassword);
    }
}