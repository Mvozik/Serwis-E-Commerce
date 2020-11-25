using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using E_Commerce.ShopModule.Services.IService;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dbContext;
        

        public ProductService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OperationResult> DeleteProductByIdAsync(int id)
        {
            var advert = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            
            if(advert==null)
            {
                return new OperationResult { Errors= new[] { "Advert with this ID doesn't exist" },Success=false };
            }

            _dbContext.Products.Remove(advert);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Id=advert.Id, Success=true };
        }

        public async Task<OperationResult> UpdateProductAsync(PutProductDto putProductDto)
        {
            var entityAdvert = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == putProductDto.Id);
            
            if(entityAdvert!=null)
            {
                entityAdvert.Name = putProductDto.Name;
                entityAdvert.Price = putProductDto.Price;
                entityAdvert.Quantity = putProductDto.Quantity;
                entityAdvert.Specification = putProductDto.Specification;
                entityAdvert.Description = putProductDto.Description;
                if(putProductDto.ProductPhoto!=null)
                {
                    entityAdvert.ProductPhoto = await GetFileAsByteArrayAsync(putProductDto.ProductPhoto);
                }
                

                _dbContext.Products.Update(entityAdvert);
                await _dbContext.SaveChangesAsync();
                return new OperationResult { Id = entityAdvert.Id, Success = true };
            }

            return new OperationResult {Success = false, Errors = new[] { "Advert with this ID doesn't exist" } };
        }

        public async Task<OperationResult> PostProductAsync(PostProductDto postProductDto)
        {
            var subCategory = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == postProductDto.SubCategoryId);
            if(subCategory==null)
            {
                return new OperationResult { Success = false, Errors = new[] { "Sub Category do not exist" } };
            }
            var product = new Product
            {
                Name = postProductDto.Name,
                Description = postProductDto.Description,
                Price = postProductDto.Price,
                Specification = postProductDto.Specification,
                Quantity = postProductDto.Quantity,
                SubCategory = subCategory
            };
            

            product.ProductPhoto = await GetFileAsByteArrayAsync(postProductDto.ProductPhoto);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Success = true, Id = product.Id};  
        }
        private async Task<byte[]> GetFileAsByteArrayAsync(IFormFile ProductPhoto)
        {
            if (ProductPhoto != null)
            {
                if (ProductPhoto.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = ProductPhoto.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        await fs1.CopyToAsync(ms1);
                        p1 = ms1.ToArray();
                    }
                    return p1;
                }
               
            }
            return null;
        }

    }

    
}
