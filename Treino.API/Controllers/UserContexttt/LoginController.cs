//using Microsoft.AspNetCore.Mvc;
//using Users.API.DataBase.Request;
//using Users.API.Services;

//namespace Users.API.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class LoginController : ControllerBase
//{
//    private LoginService loginService;

//    public LoginController(LoginService loginService)
//    {
//        this.loginService = loginService;
//    }

//    [HttpPost]
//    public async Task<IActionResult> LogarUser(LoginRequest loginRequest)
//    {
//        try
//        {
//            var token = await loginService.LogarUser(loginRequest);
//            return Ok(token);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//            return Unauthorized();
//        }
//    }
//}
