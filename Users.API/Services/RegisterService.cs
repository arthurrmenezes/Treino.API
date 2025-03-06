using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Users.API.DataBase.Dtos;
using Users.API.DataBase.Request;
using Users.API.Exceptions;
using Users.API.Models;

namespace Users.API.Services;

public class RegisterService
{
    private IMapper mapper;
    private UserManager<IdentityUser<int>> userManager;
    private EmailService emailService;

    public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.emailService = emailService;
    }

    public async Task<string> CadastrarUser(UserDto userDto)
    {
        if (userDto.Password != userDto.RePassword)
        {
            throw new PasswordMismatchException("A Password é diferente da RePassword!");
        }

        var existingUser = await userManager.FindByEmailAsync(userDto.Email);
        if (existingUser != null)
        {
            throw new ApplicationException("Já existe um usuário cadastrado com este e-mail.");
        }

        UserModel userModel = mapper.Map<UserModel>(userDto);
        IdentityUser<int> userIdentity = mapper.Map<IdentityUser<int>>(userModel);
        var resultadoIdentity = await userManager.CreateAsync(userIdentity, userDto.Password);

        if (!resultadoIdentity.Succeeded)
        {
            var errors = string.Join(", ", resultadoIdentity.Errors.Select(e => e.Description));
            Console.WriteLine(errors);
            throw new ApplicationException("Erro ao criar usuário!");
        }
        var code = userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
        var encodedCode = HttpUtility.UrlEncode(code);
        emailService.EnviarEmail(new[] { userIdentity.Email }, "Confirmação de e-mail", userIdentity.Id, encodedCode);
        return code;
    }

    public async Task AtivarContaUser(AtivaContaRequest request)
    {
        var identityUser = userManager.Users
            .FirstOrDefault(u => u.Id.Equals(request.UserId));
        var identityResult = userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
    }
}
