﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public string UserId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public bool Active { get; set; }
        public bool Realized { get; set; }
        public string Description { get; set; }
    }
}
