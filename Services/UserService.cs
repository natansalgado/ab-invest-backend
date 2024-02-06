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

        public UserService(IUserRepository repository, IUserMappingService mappingService)
        {
            _repository = repository;
            _mappingService = mappingService;
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

        public UserModel Create(CreateUserDto user)
        {
            UserModel userModel = _mappingService.CreateDtoToModel(user);
            return _repository.Create(userModel);
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