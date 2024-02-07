using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel GetByEmail(string email);
        UserModel Create(UserModel user);
        UserModel Update(int id, UserModel user);
        bool Delete(int id);

        bool EmailAlreadyInUse(string email);
    }
}