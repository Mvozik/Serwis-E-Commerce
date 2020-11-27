using E_Commerce.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Data
{
    public class DataContext : IdentityDbContext<User,IdentityRole,string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MainPageItem> MainPageItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShoppingCartItem>()
                .HasOne(p => p.ShoppingCart)
                .WithMany(t => t.ShoppingCartItems)
                .HasForeignKey(p => p.ShoppingCartId)
                .IsRequired();

            builder.Entity<ShoppingCartItem>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .IsRequired(); 

            builder.Entity<Category>()
                .HasOne(p => p.Section)
                .WithMany(t=>t.Categories)
                .HasForeignKey(p => p.SectionId)
                .IsRequired(); 

            builder.Entity<SubCategory>()
                .HasOne(p => p.Category)
                .WithMany(t => t.SubCategories)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            builder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany()
                .HasForeignKey(p => p.SubCategoryId)
                .IsRequired();

            builder.Entity<MainPageItem>()
               .HasOne(p => p.Product)
               .WithMany()
               .HasForeignKey(p => p.ProductId)
               .IsRequired();
            base.OnModelCreating(builder);
        }

    }
}
