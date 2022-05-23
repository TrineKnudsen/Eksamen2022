using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SOSU2022_BackEnd.Security.Models;

namespace SOSU2022_BackEnd.Security.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly AuthDbContext _ctx;

        public SecurityService(IConfiguration configuration, AuthDbContext ctx )
        {
            _ctx = ctx;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public JwtToken GenerateJwtToken(string username, string password)
        {
            //Validate user - Generate Token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);
            return new JwtToken
            {
                Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "Ok"
            };
        }
    }
}