using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        
       
        public string UserId { get; set; }
        public double Quantity { get; set; }
        public Advert Advert { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
    }
}
