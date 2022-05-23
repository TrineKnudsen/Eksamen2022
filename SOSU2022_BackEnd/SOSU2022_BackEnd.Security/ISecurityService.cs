using SOSU2022_BackEnd.Security.Models;

namespace SOSU2022_BackEnd.Security
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);
    }
}