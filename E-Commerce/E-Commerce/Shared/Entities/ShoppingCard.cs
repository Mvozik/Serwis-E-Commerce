using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class ShoppingCard : BaseEntity
    {
        public int UserId { get; set; }
        public List<ShoppingCardItem> ShoppingCardItems { get; set; }

    }
}
