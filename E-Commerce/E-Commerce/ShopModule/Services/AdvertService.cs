using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.AdvertDtos;
using E_Commerce.ShopModule.Services.IService;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly DataContext _dbContext;
        

        public AdvertService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Advert>> GetAdvertsAsync()
        {
            return await _dbContext.Adverts.ToListAsync();
        }


        public async Task<Advert> GetAdvertByIdAsync(int id)
        {
            return await _dbContext.Adverts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OperationResult> DeleteAdvertByIdAsync(int id)
        {
            var advert = await _dbContext.Adverts.FirstOrDefaultAsync(x => x.Id == id);
            
            if(advert==null)
            {
                return new OperationResult { Errors= new[] { "Advert with this ID doesn't exist" },Success=false };
            }

            _dbContext.Adverts.Remove(advert);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Id=advert.Id, Success=true };
        }

        public async Task<OperationResult> UpdateAdvertAsync(PutAdvertDto putAdvertDto)
        {
            var entityAdvert = await _dbContext.Adverts.FirstOrDefaultAsync(x => x.Id == putAdvertDto.Id);
            
            if(entityAdvert!=null)
            {
                entityAdvert.Name = putAdvertDto.Name;
                entityAdvert.Price = putAdvertDto.Price;
                entityAdvert.Quantity = putAdvertDto.Quantity;
                entityAdvert.Specification = putAdvertDto.Specification;
                entityAdvert.Description = putAdvertDto.Specification;
                _dbContext.Adverts.Update(entityAdvert);
                await _dbContext.SaveChangesAsync();
                return new OperationResult { Id = entityAdvert.Id, Success = true };
            }

            return new OperationResult {Success = false, Errors = new[] { "Advert with this ID doesn't exist" } };
        }

        public async Task<OperationResult> PostAdvertAsync(PostAdvertDto postAdvertDto)
        {
                var entityAdvert = postAdvertDto.Adapt<Advert>();
                await _dbContext.Adverts.AddAsync(entityAdvert);
                
                return new OperationResult { Success = true , Id = entityAdvert.Id };  
        }
    }
}
