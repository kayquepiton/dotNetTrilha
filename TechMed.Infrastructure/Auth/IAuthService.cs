using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace TechMed.Infrastructure.Auth;
public interface IAuthService
{   
    string GenerateJwtToken(string username, string role);
    string ComputeSha256Hash(string pass);
}
