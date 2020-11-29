using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class Order:BaseEntity
    {

        [ForeignKey("UserInformationsId")]
        public UserInformations UserInformations { get; set; }
        public int UserInformationsId { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }

        public bool Company { get; set; }
        public bool IsPayed { get; set; }
        public bool IsShipped { get; set; }
        public bool IsRealized { get; set; }
        
    }
}
