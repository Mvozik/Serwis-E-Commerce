﻿using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<OperationResult> DeleteProductByIdAsync(int id);
        Task<OperationResult> UpdateProductAsync(PutProductDto putAdvertDto);
        Task<OperationResult> PostProductAsync(PostProductDto postAdvertDto);
        Task<List<Product>> GetProductsBySectionIdAsync(int id);
        Task<List<MainPageItem>> GetMainPageItemsAsync();
        Task<MainPageItem> AddMainPageItem(PostMainPageItem postMainPageItem);
        Task<List<Product>> GetProductsByCategoryIdAsync(int id);
        Task<List<Product>> GetProductsBySubCategoryIdAsync(int id);

    }
}
