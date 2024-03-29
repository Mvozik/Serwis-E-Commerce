﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Dtos.ProductDtos
{
    public class PostProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public IFormFile ProductPhoto { get; set; }
        public int SubCategoryId { get; set; }
    }
}
