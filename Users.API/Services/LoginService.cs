using Azure.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Users.API.DataBase.Request;
using Users.API.Models;

namespace Users.API.Services;

public class LoginService
{
    private SignInManager<IdentityUser<int>> signInManager;
    private TokenService tokenService;

    public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
    {
        this.signInManager = signInManager;
        this.tokenService = tokenService;
    }

    public async Task<Token> LogarUser(LoginRequest loginRequest)
    {
        var resultadoIdentity = await signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);

        if (!resultadoIdentity.Succeeded)
        {
            if (resultadoIdentity.IsLockedOut)
            {
                throw new AuthenticationFailedException("Conta bloqueada devido a várias tentativas de login inválidas.");
            }

            var user = await signInManager.UserManager.FindByNameAsync(loginRequest.Username);
            if (user != null && !user.EmailConfirmed)
            {
                throw new AuthenticationFailedException("Não é possível fazer login sem email confirmado.");
            }
            throw new AuthenticationFailedException("Falha no login!");
        }
        else
        {
            var identityUser = signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedUserName == loginRequest.Username.ToUpper());

            Token token = tokenService.CreateToken(identityUser);
            return token;
        }
    }
}
