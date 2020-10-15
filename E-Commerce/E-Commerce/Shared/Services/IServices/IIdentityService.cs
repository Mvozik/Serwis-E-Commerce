using E_Commerce.Shared.Dtos;
using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Services.IServices
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserPostRegistrationDto request);
        Task<AuthenticationResult> LoginAsync(UserPostLoginDto request);
    }
}
