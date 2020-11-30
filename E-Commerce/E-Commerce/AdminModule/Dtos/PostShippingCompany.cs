using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Dtos
{
    public class PostShippingCompany
    { 
        public string CompanyName { get; set; }
        public double Price { get; set; }
    }
}
