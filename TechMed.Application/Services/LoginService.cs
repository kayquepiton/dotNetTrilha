using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Infrastructure.Auth;

namespace TechMed.Application.Services;
public class LoginService : ILoginService
{
    private readonly IAuthService _authService;

    public LoginService(IAuthService authService)
    {
        _authService = authService;
    }
    public LoginViewModel? Authenticate(LoginInputModel login)
    {
        var passHash = _authService.ComputeSha256Hash(login.Password);
        if(login.Username == "admin" && passHash == _authService.ComputeSha256Hash("admin"))
        {
            var token = _authService.GenerateJwtToken("admin", "admin");
            return new LoginViewModel
            {
                Username = login.Username,
                Token = token
            };
        }
        return null;
    }
}
