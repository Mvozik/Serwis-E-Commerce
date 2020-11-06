using E_Commerce.Shared.Dtos;
using E_Commerce.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Services.IServices
{
    public interface IUserService
    {
        IEnumerable<Claim> GetClaims();
        Task<User> GetCurrentUserAsync();
    }
}
