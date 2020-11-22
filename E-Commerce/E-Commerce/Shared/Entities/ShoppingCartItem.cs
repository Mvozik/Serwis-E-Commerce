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

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
