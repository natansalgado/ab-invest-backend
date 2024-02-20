using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel GetByEmail(string email);
        UserModel Create(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(UserModel userById);

        bool EmailAlreadyInUse(string email);
    }
}