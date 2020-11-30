using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class ShippingCompany:BaseEntity
    {
        public string CompanyName { get; set; }
        public double Price { get; set; }
    }
}
