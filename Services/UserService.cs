using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Models;
using AB_INVEST.Repositories;

namespace AB_INVEST.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<UserModel> GetAll()
        {
            return _repository.GetAll();
        }

        public UserModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        public UserModel Create(UserModel user)
        {
            return _repository.Create(user);
        }

        public UserModel Update(int id, UserModel user)
        {
            return _repository.Update(id, user);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool EmailAlreadyInUse(string email)
        {
            return _repository.EmailAlreadyInUse(email);
        }
    }
}