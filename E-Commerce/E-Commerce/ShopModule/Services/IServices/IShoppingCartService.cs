using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IShoppingCartService
    {

        Task<AddProductToShoppingCard> AddProductToShoppingCard(AddProductToShoppingCartDto addAdvertToShoppingCard);
        Task<ShoppingCart> GetUserShoppingCardAsync();
        Task<List<ShoppingCart>> GetUserShoppingCardsAsync();
        Task<ShoppingCart> AddShoppingCartAsync();
        Task<int> DeleteShoppingCartAsync(int id);
        Task<ShoppingCart> ChangeActiveShoppingCartAsync(int id);
        Task<List<ShoppingCart>> UserShoppingCardsAsync();
        Task<OperationResult> DeleteProductFromShoppingCartAsync(int ShoppingCardItemId);
        Task<bool> DeleteAllProductsFromShoppingCartAsync(int ShoppingCardId);
        Task<ShoppingCartItem> ChangeQuantityAsync(ChangeQuantityDto changeQuantityDto);
        Task<bool> ChangeExistingShoppingCartActiveValueAndGenerateNew(ShoppingCart shoppingCart, User user);
    }
}
