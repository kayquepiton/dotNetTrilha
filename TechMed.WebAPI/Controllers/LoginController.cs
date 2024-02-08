using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;

namespace TechMed.Controllers;

[ApiController]
[Route("/api/v0.1")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    [HttpPost("login")]

    public IActionResult Login([FromBody] LoginInputModel user){
        var userViewModel = _loginService.Authenticate(user);
        if(userViewModel == null)
        {
            return Ok(userViewModel);
        }
        return Unauthorized();
    }
}
