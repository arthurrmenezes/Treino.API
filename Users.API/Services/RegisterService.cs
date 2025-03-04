using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Users.API.DataBase.Dtos;
using Users.API.Models;

namespace Users.API.Services;

public class RegisterService
{
    private IMapper mapper;
    private UserManager<IdentityUser<int>> userManager;

    public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }

    public async Task<string> CadastrarUser(UserDto userDto)
    {
        UserModel userModel = mapper.Map<UserModel>(userDto);
        IdentityUser<int> userIdentity = mapper.Map<IdentityUser<int>>(userModel);
        var resultadoIdentity = await userManager.CreateAsync(userIdentity, userDto.Password);

        if (!resultadoIdentity.Succeeded)
        {
            throw new ApplicationException("Erro ao criar usuário!");
        }
        else
        {
            var code = await userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
            return code;
        }
    }
}
