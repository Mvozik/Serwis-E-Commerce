using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ProductDtos
{
    public class PostMainPageItem
    {
        public int ProductId { get; set; }
        public int Order { get; set; }
    }
}
