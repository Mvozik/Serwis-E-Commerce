using E_Commerce.ShopModule.Dtos.AdvertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IAdvertService
    {
        Task<List<GetAdvertsDto>> GetAdverts();
    }
}
