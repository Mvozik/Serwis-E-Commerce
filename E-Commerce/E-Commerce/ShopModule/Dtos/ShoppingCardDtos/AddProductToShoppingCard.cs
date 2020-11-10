using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ShoppingCardDtos
{
    public class AddProductToShoppingCard
    {
        public int ShoppingCardId { get; set; }
        public int ProductId { get; set; }

    }
}
