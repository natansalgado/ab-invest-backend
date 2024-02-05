using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Create(UserModel user);
        UserModel Update(int id, UserModel user);
        bool Delete(int id);

        bool EmailAlreadyInUse(string email);
    }
}