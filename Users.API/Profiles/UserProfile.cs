using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Users.API.DataBase.Dtos;
using Users.API.Models;

namespace Users.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserModel>();
        CreateMap<UserModel, IdentityUser>();
    }
}
