using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ShoppingCardDtos
{
    public class AddProductToShoppingCard
    {
        public int ShoppingCartId { get; set; }
        public string Error { get; set; }
        public bool Succes { get; set; }
        public int ProductId { get; set; }
        public ShoppingCartItem shoppingCartItem { get; set; }
    }
}
