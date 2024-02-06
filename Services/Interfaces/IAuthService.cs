using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;

namespace AB_INVEST.Services.Interfaces
{
    public interface IAuthService
    {
        UserModel GetByCredentials(AuthLoginDto login);
        string GenerateToken(UserModel user);
    }
}