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
        public int? UserInformationsId { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }
        public int? ShoppingCartId { get; set; }
        public string ShippingFormat { get; set; }
        public double ShippingPrice { get; set; }
        public double TotalPrice { get; set; }
        public bool Company { get; set; }
        public bool IsPayed { get; set; }
        public bool IsShipped { get; set; }
        public bool IsRealized { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PayTime { get; set; }
        public DateTime ShippedTime { get; set; }
        public DateTime RealizationTime { get; set; }

    }
}
