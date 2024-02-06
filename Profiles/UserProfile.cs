using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_INVEST.Dtos;
using AB_INVEST.Models;
using AutoMapper;

namespace AB_INVEST.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, UserModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"));

            CreateMap<UserModel, UserDto>();
        }
    }
}