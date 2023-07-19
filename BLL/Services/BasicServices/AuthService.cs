using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL.Helpers.PasswordHasher;
using CarShop.Data_Access_Layer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarShop.BLL.Services.BasicServices
{
    public class AuthService
    {
        private readonly CarsDbContext _context;
        private readonly string _sendGridApiKey;
        private readonly IPasswordHash _hasher;

        public AuthService(CarsDbContext context, IConfiguration configuration, IPasswordHash hash)
        {
            _context = context;
            _hasher = hash;
            _sendGridApiKey = configuration.GetValue<string>("SendGridSettings:ApiKey");
        }

        public string AuthenticateUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == username);
            var passwordHash = _hasher.EncryptPassword(password, user.Id.ToByteArray());

            if (user == null || passwordHash != user.Password) return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.GivenName, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_sendGridApiKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10), // Token will expire in 10 minutes
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

