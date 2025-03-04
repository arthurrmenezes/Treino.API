using Microsoft.AspNetCore.Mvc;
using Users.API.Services;

namespace Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LogoutController : ControllerBase
{
    private LogoutService logoutService;

    public LogoutController(LogoutService logoutService)
    {
        this.logoutService = logoutService;
    }

    [HttpPost]
    public IActionResult DeslogarUser()
    {
        try
        {
            logoutService.DeslogarUser();
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Unauthorized();
        }
    }
}
