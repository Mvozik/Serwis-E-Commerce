using E_Commerce.Shared.Interfaces;
using E_Commerce.ShopModule.Dtos;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IShoppingCardService
    {
        
        AddAdvertToShoppingCard AddAdvertToShoppingCard(AddAdvertToShoppingCard addAdvertToShoppingCard);
        
    }
}
