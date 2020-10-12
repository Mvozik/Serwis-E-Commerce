using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class ShoppingCardItem : BaseEntity
    {
        public int ShoppingCardId { get; set; }
        public int UserId { get; set; }
        public double Quantity { get; set; }
        public Advert Advert { get; set; }
        
    }
}
