using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.DTOs;


namespace SOSU2022_BackEnd.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<UserDto> Login(UserDto dto)
        {
            try
            {
                var user = _userService.GetUser(dto.Username, dto.Password);
                var loginusertoreturn = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password
                };
                return Created("https//:localhost/api/Login", loginusertoreturn);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}