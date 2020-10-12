using E_Commerce.Shared.Data;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;
using E_Commerce.ShopModule.Services.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services
{
    public class ShoppingCardService : IShoppingCardService
    {
        private readonly DataContext _dbContext;

        public ShoppingCardService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AddAdvertToShoppingCard AddAdvertToShoppingCard(AddAdvertToShoppingCard addAdvertToShoppingCard)
        {
            throw new NotImplementedException();
        }
    }
}
