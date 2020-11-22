using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using E_Commerce.Shared.Services.IServices;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;
using E_Commerce.ShopModule.Services.IService;
using Microsoft.EntityFrameworkCore;
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
                .ThenInclude(p=>p.Product)
                .FirstOrDefaultAsync(s => s.UserId == user.Id && s.Active==true);
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == 1);
            

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

        public async Task<OperationResult> AddProductToShoppingCard(AddProductToShoppingCard addAdvertToShoppingCard)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            var shoppingCard = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(s => s.Id == addAdvertToShoppingCard.ShoppingCardId);
            var advert = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == addAdvertToShoppingCard.ProductId);
            if(shoppingCard==null || advert==null)
            {
                return new OperationResult { Success = false, Errors = new[] { "koszyk lub produkt nie istnieje" } };
            }
            var shoppingCardItem = new ShoppingCartItem { Product = advert, Quantity = 1, ShoppingCartId = shoppingCard.Id, UserId=shoppingCard.UserId};
            await _dbContext.ShoppingCartItems.AddAsync(shoppingCardItem);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Success = true };
        }



        public async Task<OperationResult> DeleteProductFromShoppingCart(int ShoppingCardItemId)
        {
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(sci => sci.Id == ShoppingCardItemId);
            if(shoppingCartItem ==null)
            {
                return new OperationResult { Errors=new[] {"dany przedmiot koszyka nie istnieje"}, Success = false };
            }
            _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Id = shoppingCartItem.Id, Success = true }; 
        }
    }
}
