﻿using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IShoppingCartService
    {

        Task<OperationResult> AddProductToShoppingCard(AddProductToShoppingCard addAdvertToShoppingCard);
        Task<ShoppingCart> GetUserShoppingCard();
        Task<List<ShoppingCart>> UserShoppingCardsAsync();
        Task<OperationResult> DeleteProductFromShoppingCart(int ShoppingCardItemId);
    }
}
