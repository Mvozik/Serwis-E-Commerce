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

namespace E_Commerce.ShopModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService advertService)
        {
            _productService = advertService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetProducts()
        {

            var response = await _productService.GetProductsAsync();
            return Ok(response);

        }

        [HttpGet("mainpage")]
        public async Task<IActionResult> GetRandomProducts()
        {
           
            var response = await _productService.GetProductsAsync();
            if(response.Count>9)
            {
                var r = new Random();
                int count = response.Count;
                List<Product> products = new List<Product>();
                for (int i = 0; i < 9; i++)
                {
                    int indexVal = r.Next(count);
                    products.Add(response[indexVal]);
                }

                return Ok(products);
            }
            return BadRequest();

        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);

            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> PutProduct([FromForm]PutProductDto advert)
        {
            var response = await _productService.UpdateProductAsync(advert);
            if (response.Success == false)
            {
                return BadRequest(new OperationFailedResponse { Errors = response.Errors });
            }
            return Ok(response.Id);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm]PostProductDto postProductDto)
        {
            var response = await _productService.PostProductAsync(postProductDto);
            if(response.Success==true)
            {
                return Ok(response.Id);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductByIdAsync(id);
            if(response.Success==false)
            {
                return BadRequest(new OperationFailedResponse { Errors = response.Errors });
            }
            return Ok(response.Id);
        }

        [HttpGet("products-by-section")]
        public async Task<IActionResult> GetSectionCategories(int id)
        {
            var response = await _productService.GetProductsBySectionIdAsync(id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
