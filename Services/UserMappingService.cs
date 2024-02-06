using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AB_INVEST.Services.Interfaces;
using AutoMapper;

namespace AB_INVEST.Services
{
    public class UserMappingService : IUserMappingService
    {
        private readonly IMapper _mapper;

        public UserMappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto ModelToDto(UserModel user)
        {
            return _mapper.Map<UserDto>(user);
        }

        public List<UserDto> ModelListToDtoList(List<UserModel> users)
        {
            return _mapper.Map<List<UserDto>>(users);
        }

        public UserModel CreateDtoToModel(CreateUserDto user)
        {
            return _mapper.Map<UserModel>(user);
        }
    }
}