using E_Commerce.AdminModule.Dtos;
using E_Commerce.AdminModule.Services.IServices;
using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Services
{
    public class ShippingCompanyService : IShippingCompanyService
    {
        private readonly DataContext _dbContext;
        public ShippingCompanyService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ShippingCompany>> GetShippingCompaniesAsync()
        {
            return await _dbContext.ShippingCompanies.ToListAsync();
        }

        public async Task<ShippingCompany> PostShippingCompany(PostShippingCompany shippingCompany)
        {
            var newCompany = new ShippingCompany { Price = shippingCompany.Price, CompanyName = shippingCompany.CompanyName };
            var newEntity = await  _dbContext.ShippingCompanies.AddAsync(newCompany);
            await _dbContext.SaveChangesAsync();
            return newEntity.Entity;
        }
    }
}
