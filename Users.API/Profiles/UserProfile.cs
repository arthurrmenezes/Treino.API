using AutoMapper;
using Users.API.DataBase.Dtos;
using Users.API.Models;

namespace Users.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserModel>();
    }
}
