using E_Commerce.AdminModule.Dtos;
using E_Commerce.AdminModule.Services.IService;
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

namespace E_Commerce.AdminModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dbContext;
        private readonly IUserService _userService;
        private readonly IShoppingCartService _shoppingCartService;
        public OrderService(DataContext dbContext, IUserService userService, IShoppingCartService shoppingCartService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _shoppingCartService = shoppingCartService;
        }



        public async Task<ChangeStatusResponse> ChangeOrderPaymentStatus(int id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return new ChangeStatusResponse { Succes = false };
            }

            order.IsPayed =! order.IsPayed;

            order.PayTime = DateTime.Now;

            _dbContext.Orders.Update(order);

            await _dbContext.SaveChangesAsync();

            return new ChangeStatusResponse { Succes = true, NewStatus = order.IsPayed };
        }

        public async Task<ChangeStatusResponse> ChangeOrderRealizationStatus(int id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return new ChangeStatusResponse { Succes = false };
            }

            order.IsRealized = !order.IsRealized;

            order.RealizationTime = DateTime.Now;

            _dbContext.Orders.Update(order);

            await _dbContext.SaveChangesAsync();

            return new ChangeStatusResponse { Succes = true, NewStatus = order.IsRealized };
        }

        public async Task<ChangeStatusResponse> ChangeOrderShippingStatus(int id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return new ChangeStatusResponse { Succes = false };
            }

            order.IsShipped = !order.IsShipped;
            order.ShippedTime = DateTime.Now;
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();

            return new ChangeStatusResponse { Succes = true, NewStatus = order.IsShipped };
        }

        public async Task<List<Order>> GetActiveOrders()
        {
            var orders = await _dbContext.Orders.Where(x => x.IsRealized == false).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetRealizedOrders()
        {
            var orders = await _dbContext.Orders.Where(x => x.IsRealized == true).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetUserOrders()
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            return await _dbContext.Orders
                .Include(p => p.ShoppingCart)
                .Include(p => p.UserInformations)
                .Where(x => x.ShoppingCart.UserId == user.Id)
                .ToListAsync();
        }

        public async Task<Order> PostOrderAsync(PostOrderDto postOrderDto)
        {
            var user = await _userService.GetCurrentUserWithInformationsAsync();

            if (user == null)
            {
                return null;
            }

            var shoppingCart = await _dbContext.ShoppingCarts.Include(p => p.ShoppingCartItems).ThenInclude(p => p.Product).FirstOrDefaultAsync(x => x.UserId == user.Id && x.Active == true);
            if (shoppingCart == null)
            {
                return null;
            }

            var order = new Order
            {
                IsPayed = false,
                IsRealized = false,
                IsShipped = false,
                ShoppingCart = shoppingCart,
                UserInformations = user.UserInformations,
                ShippingFormat = postOrderDto.ShippingCompany
            };

            if (user.UserInformations.Nip != "")
            {
                order.Company = true;
            }
            else
            {
                order.Company = false;
            }

            double totalCost = 0;

            foreach (var item in shoppingCart.ShoppingCartItems)
            {
                totalCost += item.Product.Price * item.Quantity;
            }

            totalCost += postOrderDto.ShippingPrice;
            order.TotalPrice = totalCost;
            var newOrder = await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            await _shoppingCartService.ChangeExistingShoppingCartActiveValueAndGenerateNew(shoppingCart, user);
            return newOrder.Entity;
        }
    }


}
