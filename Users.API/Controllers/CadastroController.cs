using Microsoft.AspNetCore.Mvc;
using Users.API.DataBase.Dtos;
using Users.API.Services;

namespace Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CadastroController : ControllerBase
{
    private UserService userService;

    public CadastroController(UserService userService)
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
