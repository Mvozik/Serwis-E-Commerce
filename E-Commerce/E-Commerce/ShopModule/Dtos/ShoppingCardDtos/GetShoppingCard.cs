using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ShoppingCardDtos
{
    public class GetShoppingCard
    {
        public int Id { get; set; }
        public List<Advert> Adverts { get; set; }

    }
}
