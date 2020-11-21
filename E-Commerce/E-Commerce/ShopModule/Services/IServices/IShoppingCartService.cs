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

        Task<AddProductToShoppingCard> AddProductToShoppingCard(AddProductToShoppingCard addAdvertToShoppingCard);
        Task<ShoppingCart> GetUserShoppingCard();
        Task<List<ShoppingCart>> UserShoppingCardsAsync();
        Task<OperationResult> DeleteProductFromShoppingCartAsync(int ShoppingCardItemId);
        Task<bool> DeleteAllProductsFromShoppingCartAsync(int ShoppingCardId);
        Task<ShoppingCartItem> ChangeQuantityAsync(ChangeQuantityDto changeQuantityDto);
    }
}
