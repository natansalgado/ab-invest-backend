using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;

namespace AB_INVEST.Services.Interfaces
{
    public interface IUserMappingService
    {
        UserDto ModelToDto(UserModel user);
        List<UserDto> ModelListToDtoList(List<UserModel> users);
        UserModel CreateDtoToModel(CreateUserDto user);
    }
}