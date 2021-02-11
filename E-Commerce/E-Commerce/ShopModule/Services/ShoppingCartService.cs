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
        public ShoppingCartService(DataContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ShoppingCart> GetUserShoppingCardAsync()
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }
            var shoppingCard = await _dbContext.ShoppingCarts
                .Include(p => p.ShoppingCartItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(s => s.UserId == user.Id && s.Active == true);
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == 1);


            if (shoppingCard == null)
            {
                await _dbContext.ShoppingCarts.AddAsync(new ShoppingCart { UserId = user.Id, Active = true });
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

        public async Task<AddProductToShoppingCard> AddProductToShoppingCard(AddProductToShoppingCartDto addAdvertToShoppingCard)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            var shoppingCart = await _dbContext.ShoppingCarts.Include(p => p.ShoppingCartItems).ThenInclude(p => p.Product).FirstOrDefaultAsync(s => s.UserId == user.Id && s.Active == true);

            var product = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == addAdvertToShoppingCard.ProductId);

            if (shoppingCart == null || product == null)
            {
                return new AddProductToShoppingCard { Succes = false, Error = "ShoppingCart or Product do not exist" };
            }
            var exist = false;
            if (shoppingCart.ShoppingCartItems.Count() > 0)
            {
                shoppingCart.ShoppingCartItems.ForEach(x =>
                {
                    if (x.Product.Id == product.Id)
                    {
                        exist = true;
                    }
                });
            }
            if (exist == false)
            {
                if (addAdvertToShoppingCard.Quantity == 0)
                {
                    addAdvertToShoppingCard.Quantity = 1;
                }

                var shoppingCartItem = new ShoppingCartItem { Product = product, Quantity = addAdvertToShoppingCard.Quantity, ShoppingCartId = shoppingCart.Id, UserId = shoppingCart.UserId };
                var newShoppingCart = await _dbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
                await _dbContext.SaveChangesAsync();

                return new AddProductToShoppingCard { Succes = true, shoppingCartItem = newShoppingCart.Entity };
            }

            return new AddProductToShoppingCard { Succes = false, Error = "Product already exist" };
        }

        public async Task<OperationResult> DeleteProductFromShoppingCartAsync(int ShoppingCardItemId)
        {
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(sci => sci.Id == ShoppingCardItemId);
            if (shoppingCartItem == null)
            {
                return new OperationResult { Errors = new[] { "dany przedmiot koszyka nie istnieje" }, Success = false };
            }
            _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
            await _dbContext.SaveChangesAsync();
            return new OperationResult { Id = shoppingCartItem.Id, Success = true };
        }

        public async Task<bool> DeleteAllProductsFromShoppingCartAsync(int shoppingCardId)
        {
            var shoppingCartItems = await _dbContext.ShoppingCartItems.Where(x => x.ShoppingCartId == shoppingCardId).ToListAsync();
            if (shoppingCartItems == null)
            {
                return false;
            }
            _dbContext.ShoppingCartItems.RemoveRange(shoppingCartItems);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingCartItem> ChangeQuantityAsync(ChangeQuantityDto changeQuantityDto)
        {
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(x => x.Id == changeQuantityDto.ShoppingCartItemId);
            if (shoppingCartItem == null)
            {
                return null;
            }
            shoppingCartItem.Quantity = changeQuantityDto.Quantity;
            _dbContext.ShoppingCartItems.Update(shoppingCartItem);
            await _dbContext.SaveChangesAsync();
            var response = await _dbContext.ShoppingCartItems.Include(p => p.Product).FirstOrDefaultAsync(x => x.Id == changeQuantityDto.ShoppingCartItemId);
            return response;
        }


        public async Task<bool> ChangeExistingShoppingCartActiveValueAndGenerateNew(ShoppingCart shoppingCart, User user)
        {
            shoppingCart.Active = false;
            _dbContext.ShoppingCarts.Update(shoppingCart);
            await _dbContext.ShoppingCarts.AddAsync(new ShoppingCart { Active = true, UserId = user.Id });
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ShoppingCart>> GetUserShoppingCardsAsync()
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            var shoppingCarts = await _dbContext.ShoppingCarts.Include(x=>x.ShoppingCartItems).ThenInclude(x=>x.Product).Where(x => x.UserId == user.Id && x.Active == false).ToListAsync();

            if (shoppingCarts == null)
            {
                var newShoppingCart = new ShoppingCart { Active = true, UserId = user.Id };
                await _dbContext.ShoppingCarts.AddAsync(newShoppingCart);
                await _dbContext.SaveChangesAsync();
                shoppingCarts.Add(newShoppingCart);
            }

            return shoppingCarts;

        }

        public async Task<ShoppingCart> AddShoppingCartAsync()
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            var activeShoppingCart = await _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems).FirstOrDefaultAsync(x => x.UserId == user.Id && x.Active == true);

            var newShoppingCart = new ShoppingCart { Active = true, UserId = user.Id };

            if (activeShoppingCart == null)
            {
                var response = await _dbContext.ShoppingCarts.AddAsync(newShoppingCart);
                await _dbContext.SaveChangesAsync();
                var newEntity = await _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems)
                    .ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == response.Entity.Id);
                return newEntity;
            }

            if (activeShoppingCart.ShoppingCartItems.Count > 0)
            {

                activeShoppingCart.Active = false;
                _dbContext.ShoppingCarts.Update(activeShoppingCart);
                var response2 = await _dbContext.ShoppingCarts.AddAsync(newShoppingCart);
                await _dbContext.SaveChangesAsync();
                var newEntity2 = await _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems)
                    .ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == response2.Entity.Id);
                return newEntity2;

            }

            return null;
        }

        public async Task<int> DeleteShoppingCartAsync(int id)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return 0;
            }
            var shoppingCartEntity = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == user.Id && x.Id == id);
            _dbContext.ShoppingCarts.Remove(shoppingCartEntity);
            await _dbContext.SaveChangesAsync();
            return shoppingCartEntity.Id;
        }

        public async Task<ShoppingCart> ChangeActiveShoppingCartAsync(int id)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            var activeShoppingCart = await _dbContext.ShoppingCarts.Include(x => x.ShoppingCartItems).FirstOrDefaultAsync(x => x.UserId == user.Id && x.Active == true);

            if(activeShoppingCart == null)
            {
                return null;
            }

            var newActiveShoppingCart = await _dbContext.ShoppingCarts.Include(x=>x.ShoppingCartItems).ThenInclude(x=>x.Product).FirstOrDefaultAsync(x => x.UserId == user.Id && x.Id == id);


            if (newActiveShoppingCart == null)
            {
                return null;
            }

            if(activeShoppingCart.ShoppingCartItems.Count == 0)
            {
                _dbContext.ShoppingCarts.Remove(activeShoppingCart);
                newActiveShoppingCart.Active = true;
                _dbContext.ShoppingCarts.Update(newActiveShoppingCart);
                await _dbContext.SaveChangesAsync();
                return newActiveShoppingCart;
            }
            else
            {
                activeShoppingCart.Active = false;
                newActiveShoppingCart.Active = true;
                _dbContext.ShoppingCarts.UpdateRange(activeShoppingCart, newActiveShoppingCart);
                await _dbContext.SaveChangesAsync();
                return newActiveShoppingCart;
            }
           

        }
    }
}
