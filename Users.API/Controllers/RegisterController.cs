using Microsoft.AspNetCore.Mvc;
using Users.API.DataBase.Dtos;
using Users.API.DataBase.Request;
using Users.API.Services;

namespace Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private RegisterService registerService;

    public RegisterController(RegisterService registerService)
    {
        this.registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUser(UserDto userDto)
    {
        try
        {
            var resultado = await registerService.CadastrarUser(userDto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("/ativarConta")]
    public async Task<IActionResult> AtivarContaUser([FromQuery] AtivaContaRequest request)
    {
        try
        {
            await registerService.AtivarContaUser(request);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
}
