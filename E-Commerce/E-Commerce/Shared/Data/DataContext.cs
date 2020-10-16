using E_Commerce.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Data
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Advert> adverts { get; set; }
        public DbSet<ShoppingCard> shoppingCards { get; set; }
        public DbSet<ShoppingCardItem> shoppingCardItems { get; set; }
        
    }
}
