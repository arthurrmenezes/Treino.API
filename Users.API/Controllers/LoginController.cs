using Microsoft.AspNetCore.Mvc;
using Users.API.Services;

namespace Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private LoginService loginService;

    public LoginController(LoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost]
    public IActionResult LogarUser()
    {
        return Ok();
    }
}
