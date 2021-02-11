using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ShoppingCardDtos
{
    public class AddProductToShoppingCartDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
