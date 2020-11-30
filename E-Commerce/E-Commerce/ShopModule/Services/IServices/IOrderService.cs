using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.OrderDtos;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ShopModule.Services.IService
{
    public interface IOrderService
    {
        Task<Order> PostOrderAsync (PostOrderDto postOrderDto);
        Task<List<Order>> GetUserOrders ();
        

    }
}
