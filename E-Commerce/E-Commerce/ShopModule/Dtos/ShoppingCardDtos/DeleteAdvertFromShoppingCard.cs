using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ShoppingCardDtos
{
    public class DeleteAdvertFromShoppingCard
    {
        public int ShoppingCardId { get; set; }
        public int UserId { get; set; }
    }
}
