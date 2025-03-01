using Microsoft.AspNetCore.Mvc;
using Users.API.DataBase.Dtos;
using Users.API.Services;

namespace Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private RegisterService userService;

    public RegisterController(RegisterService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public IActionResult CadastrarUsuario(UserDto userDto)
    {
        userService.AdicionarUser(userDto);
        return Created();
    }
}
