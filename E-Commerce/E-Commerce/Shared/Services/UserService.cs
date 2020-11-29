using E_Commerce.Shared.Data;
using E_Commerce.Shared.Dtos;
using E_Commerce.Shared.Entities;
using E_Commerce.Shared.Models;
using E_Commerce.Shared.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserInformations> CreateEmptyUserInformationsAsync()
        {
            var created = await _context.UserInformations.AddAsync(new UserInformations());
            return created.Entity;
        }

        public IEnumerable<Claim> GetClaims()
        {
            var claims = _httpContextAccessor.HttpContext?.User?.Claims;

            if (claims == null)
                return Enumerable.Empty<Claim>();

            return claims;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var userClaims = GetClaims().ToList();

            if (userClaims.Any())
            {
                var name = userClaims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                return await _userManager.FindByNameAsync(name);
            }

            return null;
        }
        public async Task<User> GetCurrentUserWithInformationsAsync()
        {
            var userClaims = GetClaims().ToList();

            if (userClaims.Any())
            {
                var name = userClaims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                return await _context.Users.Include(p => p.UserInformations).FirstOrDefaultAsync(x => x.UserName == name);
            }

            return null;
        }
        


    }
}
