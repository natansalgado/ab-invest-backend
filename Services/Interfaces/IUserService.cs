using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;

namespace AB_INVEST.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        UserModel Create(CreateUserDto user);
        UserModel Update(int id, UserModel user);
        bool Delete(int id);

        bool EmailAlreadyInUse(string email);
    }
}