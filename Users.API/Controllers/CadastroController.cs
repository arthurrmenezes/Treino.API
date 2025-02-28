using Microsoft.AspNetCore.Mvc;
using Users.API.Models;

namespace Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CadastroController : ControllerBase
{
    [HttpPost]
    public IActionResult CadastrarUsuario(UserModel usuario)
    {
        return Ok();
    }
}
