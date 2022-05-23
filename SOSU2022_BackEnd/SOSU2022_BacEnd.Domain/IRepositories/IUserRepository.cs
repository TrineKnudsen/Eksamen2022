using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.IRepositories
{
    public interface IUserRepository
    {
        User FindByUsernameAndPassWord(string username, string password);
    }
}