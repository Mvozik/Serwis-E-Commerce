using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using E_Commerce.Shared.Services.IServices;
using E_Commerce.ShopModule.Dtos.OrderDtos;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using E_Commerce.ShopModule.Services.IService;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dbContext;
        private readonly IUserService _userService;

        public OrderService(DataContext dbContext,IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<List<Order>> GetUserOrders()
        {
            var user = await _userService.GetCurrentUserAsync();
            if(user==null)
            {
                return null;
            }

            return await _dbContext.Orders
                .Include(p=>p.ShoppingCart)
                .Include(p=>p.UserInformations)
                .Where(x => x.ShoppingCart.UserId == user.Id)
                .ToListAsync();
        }

        public async Task<Order> PostOrderAsync(PostOrderDto postOrderDto)
        {
            var user = await _userService.GetCurrentUserWithInformationsAsync();
            
            if(user==null)
            {
                return null;
            }
            
            var shoppingCart = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(x=> x.UserId==user.Id && x.Active == true);
            if(shoppingCart==null)
            {
                return null;
            }

            var order = new Order
            {
                Company = postOrderDto.Company,
                IsPayed = false,
                IsRealized = false,
                IsShipped = false,
                ShoppingCart = shoppingCart,
                UserInformations = user.UserInformations,
            };

            var newOrder = await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return newOrder.Entity;
        }
    }

    
}
