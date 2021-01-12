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
using E_Commerce.AdminModule.Services.IService;

namespace E_Commerce.AdminModule.Controllers
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

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveOrders()
        {
            var response = await _orderService.GetActiveOrders();
            return Ok(response);
        }

        [HttpGet("realized")]
        public async Task<IActionResult> GetRealizedOrders()
        {
            var response = await _orderService.GetRealizedOrders();
            return Ok(response);
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

        [HttpPatch("payment")]
        public async Task<IActionResult> ChangePayment(int id)
        {
            var response = await _orderService.ChangeOrderPaymentStatus(id);
            if (response.Succes == false)
            {
                return BadRequest();
            }
            return Ok(response.NewStatus);
        }

        [HttpPatch("shipping")]
        public async Task<IActionResult> ChangeShipping(int id)
        {
            var response = await _orderService.ChangeOrderShippingStatus(id);
            if (response.Succes == false)
            {
                return BadRequest();
            }
            return Ok(response.NewStatus);
        }

        [HttpPatch("realization")]
        public async Task<IActionResult> ChangeRealization(int id)
        {
            var response = await _orderService.ChangeOrderRealizationStatus(id);
            if(response.Succes==false)
            {
                return BadRequest();
            }
            return Ok(response.NewStatus);
        }
    }
}
