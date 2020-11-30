using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Shared.Data;
using Mapster;
using E_Commerce.ShopModule.Services.IService;
using E_Commerce.ShopModule.Dtos.ProductDtos;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using E_Commerce.Shared.Entities;
using E_Commerce.ShopModule.Dtos.OrderDtos;

namespace E_Commerce.ShopModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderService.GetUserOrders();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder (PostOrderDto postOrderDto)
        {
            var response = await _orderService.PostOrderAsync(postOrderDto);
            return Ok(response);
        }
    }
}
