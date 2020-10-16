using E_Commerce.Shared.Dtos;
using E_Commerce.Shared.Entities;
using E_Commerce.Shared.Models;
using E_Commerce.Shared.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult> LoginAsync(UserPostLoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user==null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User does not exist"}
                };
            }
            var userValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if(!userValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Email or password is wrong" }
                };
            }

            return GenerateAuthorizationForUser(user);

        }

        public async Task<AuthenticationResult> RegisterAsync(UserPostRegistrationDto request)
        {
            
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email already exist" }
                };

            }

            var newUser = new IdentityUser
            {
                Email = request.Email,
                UserName = request.Email
            };

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthorizationForUser(newUser);

        }

        private AuthenticationResult GenerateAuthorizationForUser(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
