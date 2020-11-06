using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using E_Commerce.Shared.Services.IServices;
using E_Commerce.ShopModule.Dtos.AdvertDtos;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;
using E_Commerce.ShopModule.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly DataContext _dbContext;
  
        private readonly IUserService _userService;
        public ShoppingCartService(DataContext dbContext,  IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ShoppingCart> GetUserShoppingCard()
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }
            var shoppingCard = await _dbContext.ShoppingCarts
                .Include(p=>p.ShoppingCartItems)
                .FirstOrDefaultAsync(s => s.UserId == user.Id && s.Active==true);
           

            if (shoppingCard == null)
            {
                await _dbContext.ShoppingCarts.AddAsync(new ShoppingCart { UserId = user.Id , Active=true});
                await _dbContext.SaveChangesAsync();
                var newShoppingCard = await _dbContext.ShoppingCarts.AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == user.Id && s.Active == true);
               return newShoppingCard;
            }

            
            return shoppingCard;
            
        }

        public async Task<List<ShoppingCart>> UserShoppingCardsAsync()
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }
            var shoppingCards = await _dbContext.ShoppingCarts.Where(x => x.UserId == user.Id).ToListAsync();
            return shoppingCards;
            
        }

        public async Task<OperationResult> AddAdvertToShoppingCard(AddAdvertToShoppingCard addAdvertToShoppingCard)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            var shoppingCard = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(s => s.Id == addAdvertToShoppingCard.ShoppingCardId);
            var advert = await _dbContext.Adverts.FirstOrDefaultAsync(a => a.Id == addAdvertToShoppingCard.AdvertId);
            if(shoppingCard==null || advert==null)
            {
                return new OperationResult { Success = false, Errors = new[] { "koszyk lub produkt nie istnieje" } };
            }
            var shoppingCardItem = new ShoppingCartItem { Advert = advert, Quantity = 1, ShoppingCartId = shoppingCard.Id, UserId=shoppingCard.UserId};
            await _dbContext.ShoppingCartItems.AddAsync(shoppingCardItem);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Success = true };
        }
    }
}
