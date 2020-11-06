using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.AdvertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IAdvertService
    {
        Task<List<Advert>> GetAdvertsAsync();
        Task<Advert> GetAdvertByIdAsync(int id);
        Task<OperationResult> DeleteAdvertByIdAsync(int id);
        Task<OperationResult> UpdateAdvertAsync(PutAdvertDto putAdvertDto);
        Task<OperationResult> PostAdvertAsync(PostAdvertDto postAdvertDto);
    }
}
