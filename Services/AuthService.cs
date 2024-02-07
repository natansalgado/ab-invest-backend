using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using AB_INVEST.Services.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace AB_INVEST.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHashSevice _passwordHashSevice;

        public AuthService(IUserRepository repository, IConfiguration configuration, IPasswordHashSevice passwordHashSevice)
        {
            _repository = repository;
            _configuration = configuration;
            _passwordHashSevice = passwordHashSevice;
        }

        public UserModel GetByCredentials(AuthLoginDto login)
        {
            UserModel user = _repository.GetByEmail(login.Email);

            if (user != null && _passwordHashSevice.VerifyPassword(login.Password, user.Password))
            {
                return user;
            }

            return null;
        }

        public string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Settings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Name.ToString()),
                    new(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}