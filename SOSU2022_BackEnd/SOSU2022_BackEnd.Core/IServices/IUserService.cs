using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BackEnd.Core.IServices
{
    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}