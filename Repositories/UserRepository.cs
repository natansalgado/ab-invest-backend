using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Context;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using AutoMapper;

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

            if (user.Name != null) userById.Name = user.Name;
            if (user.Email != null) userById.Email = user.Email;
            if (user.Phone != null) userById.Phone = user.Phone;
            if (user.Password != null) userById.Password = user.Password;
            if (user.Role != null) userById.Role = user.Role;

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