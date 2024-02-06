using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;

namespace AB_INVEST.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ABInvestContext _context;

        public AuthRepository(ABInvestContext context)
        {
            _context = context;
        }

        public UserModel GetByCredentials(AuthLoginDto login)
        {
            return _context.Users
                .Where(x => x.Email.ToLower() == login.Email.ToLower() && x.Password == login.Password).FirstOrDefault();
        }
    }
}