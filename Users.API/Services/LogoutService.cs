using Microsoft.AspNetCore.Identity;

namespace Users.API.Services;

public class LogoutService
{
    private SignInManager<IdentityUser<int>> signInManager;

    public LogoutService(SignInManager<IdentityUser<int>> signInManager)
    {
        this.signInManager = signInManager;
    }

    public void DeslogarUser()
    {
        var resultadoIdentity = signInManager.SignOutAsync();

        if (!resultadoIdentity.IsCompletedSuccessfully)
        {
            throw new InvalidOperationException("Falha ao deslogar!");
        }
    }
}
