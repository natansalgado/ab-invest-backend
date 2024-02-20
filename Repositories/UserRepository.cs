using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;

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

        public UserModel GetByEmail(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public UserModel Create(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public UserModel Update(UserModel user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public bool Delete(UserModel userById)
        {
            _context.Users.Remove(userById);
            _context.SaveChanges();

            return true;
        }

        public bool EmailAlreadyInUse(string email)
        {
            return _context.Users.Any(x => x.Email.ToLower() == email.ToLower());
        }
    }
}