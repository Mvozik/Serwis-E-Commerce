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
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Sections")]
        public async Task<IActionResult> GetSections()
        {
            var response = await _categoryService.GetSectionsAsync();
            return Ok(response);
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryService.GetCategoriesAsync();
            return Ok(response);
        }

        [HttpGet("SubCategory")]
        public async Task<IActionResult> GetSubCategories()
        {
            var response = await _categoryService.GetSubCategoriesAsync();
            return Ok(response);
        }

        [HttpPost("Category")]
        public async Task<IActionResult> PostCategories(PostCategoryDto postCategoryDto)
        {
            var response = await _categoryService.AddCategoryAsync(postCategoryDto);
            return Ok(response);
        }

        [HttpPost("SubCategory")]
        public async Task<IActionResult> PostSubCategories(PostSubCategoryDto postSubCategoryDto)
        {
            var response = await _categoryService.AddSubCategoryAsync(postSubCategoryDto);
            return Ok(response);

        }

        [HttpGet("products-by-section")]
        public async Task<IActionResult> GetSectionCategories(int id)
        {
            var response = await _categoryService.GetProductsBySectionIdAsync(id);
            if(response==null)
            {
                return BadRequest();
            }
            return Ok(response);
        }


    }
}
