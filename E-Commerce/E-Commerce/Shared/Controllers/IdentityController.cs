using E_Commerce.Shared.Dtos;
using E_Commerce.Shared.Dtos.Responses;
using E_Commerce.Shared.Entities;
using E_Commerce.Shared.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        public IdentityController(IIdentityService identityService, IUserService userService)
        {
            _identityService = identityService;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserPostRegistrationDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });
            }

            return Ok(new AuthSuccessResponse { Token = authResponse.Token, RefreshToken = authResponse.RefreshToken });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserPostLoginDto request)
        {
            var authResponse = await _identityService.LoginAsync(request);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });
            }

            return Ok(new AuthSuccessResponse { Token = authResponse.Token, RefreshToken = authResponse.RefreshToken });
        }

        [HttpPost("Refesh-Token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var response = await _identityService.RefreshTokenAsync(refreshTokenDto.Token, refreshTokenDto.RefreshToken);
            if(!response.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors=response.Errors });
            }
            return Ok( new AuthSuccessResponse
            { 
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            var response = await _identityService.LogoutAsync(refreshToken);
            if (!response.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = response.Errors });
            }
            return Ok();
        }

        [HttpGet("UserInformations")]
        public async Task<IActionResult> GetUserInformations()
        {
            var response = await _userService.GetUserInformationsAsync();
            if(response==null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPut("UpdateUserInformations")]
        public async Task<IActionResult> PutUserInformations(UserInformations userInformations)
        {
            var response = await _userService.PutUserInformationsAsync(userInformations);
            if (response == null)
            {
                return Ok("nie znaleziono");
            }
            return Ok(response);
        }

    }
}
