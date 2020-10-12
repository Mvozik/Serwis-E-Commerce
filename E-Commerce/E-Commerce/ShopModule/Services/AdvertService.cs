using E_Commerce.Shared.Data;
using E_Commerce.ShopModule.Dtos.AdvertDtos;
using E_Commerce.ShopModule.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<GetAdvertsDto>> GetAdverts()
        {
            throw new NotImplementedException();
        }
    }
}
