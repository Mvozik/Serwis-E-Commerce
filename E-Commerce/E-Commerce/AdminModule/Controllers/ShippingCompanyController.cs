using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Shared.Data;
using Mapster;
using E_Commerce.ShopModule.Services.IService;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using E_Commerce.Shared.Entities;
using E_Commerce.AdminModule.Services.IServices;
using E_Commerce.AdminModule.Dtos;

namespace E_Commerce.AdminModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompanyController:ControllerBase
    {
        private readonly IShippingCompanyService _shippingCompanyService;
        public ShippingCompanyController(IShippingCompanyService shippingCompanyService)
        {
            _shippingCompanyService = shippingCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShippingCompanies()
        {
            var response = await _shippingCompanyService.GetShippingCompaniesAsync();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostShippingCompanies(PostShippingCompany shippingCompany)
        {
            var response = await _shippingCompanyService.PostShippingCompany(shippingCompany);
            return Ok(response);
        }

    }
}
