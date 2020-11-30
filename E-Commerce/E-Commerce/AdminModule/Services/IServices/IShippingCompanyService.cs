using E_Commerce.AdminModule.Dtos;
using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Services.IServices
{
    public interface IShippingCompanyService
    {
        Task<List<ShippingCompany>> GetShippingCompaniesAsync();
        Task<ShippingCompany> PostShippingCompany(PostShippingCompany shippingCompany);
       
    }
}
