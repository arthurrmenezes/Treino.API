using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Users.API.DataBase.Dtos;
using Users.API.Models;

namespace Users.API.Services;

public class UserService
{
    private IMapper mapper;
    private UserManager<IdentityUser<int>> userManager;

    public UserService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }

    public void AdicionarUser(UserDto userDto)
    {
        UserModel userModel = mapper.Map<UserModel>(userDto);
        IdentityUser<int> userIdentity = mapper.Map<IdentityUser<int>>(userModel);
        var resultadoIdentity = userManager.CreateAsync(userIdentity, userDto.Password);
    }
}
