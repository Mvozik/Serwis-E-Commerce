﻿using E_Commerce.Shared.Dtos;
using E_Commerce.Shared.Dtos.Responses;
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

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register( UserPostRegistrationDto request)
        {
            if(!ModelState.IsValid)
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

            return Ok(new AuthSuccessResponse { Token = authResponse.Token });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserPostLoginDto request)
        {
            var authResponse = await _identityService.LoginAsync(request);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });
            }

            return Ok(new AuthSuccessResponse { Token = authResponse.Token });
        }

    }
}
