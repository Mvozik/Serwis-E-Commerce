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

namespace E_Commerce.AdminModule.Controllers
{
    public class CategoryController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {

            [HttpGet("Category")]
            public async Task<IActionResult> GetCategories()
            {


            }

            [HttpGet("SubCategory")]
            public async Task<IActionResult> GetSubCategories()
            {


            }

        }


    }
}
