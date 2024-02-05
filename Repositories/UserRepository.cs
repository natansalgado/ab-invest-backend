using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Models;

namespace AB_INVEST.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ABInvestContext _context;

        public UserRepository(ABInvestContext context)
        {
            _context = context;
        }

        public List<UserModel> GetAll()
        {
            return _context.Users.ToList();
        }

        public UserModel GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public UserModel Create(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel Update(int id, UserModel user)
        {
            UserModel userById = GetById(id);

            if (userById == null)
            {
                return null;
            }

            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Phone = user.Phone;
            userById.Password = user.Password;

            _context.Users.Update(userById);
            _context.SaveChanges();

            return userById;
        }

        public bool Delete(int id)
        {
            UserModel userById = GetById(id);

            if (userById == null)
            {
                return false;
            }

            _context.Users.Remove(userById);
            _context.SaveChanges();

            return true;
        }

        public bool EmailAlreadyInUse(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }
    }
}