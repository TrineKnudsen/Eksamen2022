using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;

namespace SOSU2022_BacEnd.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUser(string username, string password)
        {
            return _userRepository.FindByUsernameAndPassWord(username, password);
        }
        
    }
}