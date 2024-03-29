using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AB_INVEST.Repositories.Interfaces;
using AB_INVEST.Services.Interfaces;

namespace AB_INVEST.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserMappingService _mappingService;
        private readonly IPasswordHashSevice _passwordHashService;
        private readonly IAccountService _accountService;

        public UserService(IUserRepository repository,
            IUserMappingService mappingService,
            IPasswordHashSevice passwordHashService,
            IAccountService accountService)
        {
            _repository = repository;
            _mappingService = mappingService;
            _passwordHashService = passwordHashService;
            _accountService = accountService;
        }

        public List<UserDto> GetAll()
        {
            List<UserModel> users = _repository.GetAll();
            return _mappingService.ModelListToDtoList(users);
        }

        public UserDto GetById(int id)
        {
            UserModel user = _repository.GetById(id);
            return _mappingService.ModelToDto(user);
        }

        public UserDto Create(CreateUserDto user)
        {
            user.Password = _passwordHashService.HashPassword(user.Password);
            user.Email = user.Email.ToLower();

            UserModel userModel = _repository.Create(_mappingService.CreateDtoToModel(user));

            _accountService.Create(userModel.Id);

            UserDto userDto = _mappingService.ModelToDto(userModel);

            return userDto;
        }

        public UserDto Update(int id, UserModel user)
        {
            UserModel userById = _repository.GetById(id);

            if (userById == null)
            {
                return null;
            }

            if (user.Name != null) userById.Name = user.Name;
            if (user.Email != null) userById.Email = user.Email.ToLower();
            if (user.Phone != null) userById.Phone = user.Phone;
            if (user.Password != null) userById.Password = user.Password;
            if (user.Role != null) userById.Role = user.Role;

            user.Password = _passwordHashService.HashPassword(user.Password);

            UserDto userDto = _mappingService.ModelToDto(_repository.Update(user));

            return userDto;
        }

        public bool Delete(int id)
        {
            UserModel userById = _repository.GetById(id);

            if (userById == null) return false;

            return _repository.Delete(userById);
        }

        public bool EmailAlreadyInUse(string email)
        {
            return _repository.EmailAlreadyInUse(email);
        }
    }
}