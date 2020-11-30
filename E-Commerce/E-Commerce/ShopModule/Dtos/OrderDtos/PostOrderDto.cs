using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.OrderDtos
{
    public class PostOrderDto
    {
        public string ShippingCompany { get; set; }
        public double ShippingPrice { get; set; }
    }
}
