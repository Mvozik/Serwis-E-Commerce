using E_Commerce.AdminModule.Dtos;
using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.OrderDtos;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Services.IService
{
    public interface IOrderService
    {
        Task<Order> PostOrderAsync (PostOrderDto postOrderDto);
        Task<List<Order>> GetUserOrders ();
        Task<List<Order>> GetActiveOrders();
        Task<List<Order>> GetRealizedOrders();
        Task<ChangeStatusResponse> ChangeOrderPaymentStatus(int id);
        Task<ChangeStatusResponse> ChangeOrderShippingStatus(int id);
        Task<ChangeStatusResponse> ChangeOrderRealizationStatus(int id);
    }
}
