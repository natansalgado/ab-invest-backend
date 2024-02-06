using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        UserModel GetByCredentials(AuthLoginDto login);
    }
}