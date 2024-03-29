﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using Mapster;
using E_Commerce.ShopModule.Services.IService;
using E_Commerce.ShopModule.Dtos.ShoppingCardDtos;

namespace E_Commerce.ShopModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {

        private readonly IShoppingCartService _shoppingCardService;


        public ShoppingCartController(IShoppingCartService shoppingCardsService)
        {
            _shoppingCardService = shoppingCardsService;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetUserActiveShoppingCard()
        {
            var shoppingCard = await _shoppingCardService.GetUserShoppingCardAsync();

            return Ok(shoppingCard);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetUserShoppingCarts()
        {
            var response = await _shoppingCardService.GetUserShoppingCardsAsync();
            if (response == null)
            {
                Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost("add-to-shopping-card")]
        public async Task<IActionResult> PostAdvertToShoppingCard(AddProductToShoppingCartDto addAdvertToShoppingCard)
        {
            var shoppingCard = await _shoppingCardService.AddProductToShoppingCard(addAdvertToShoppingCard);

            if (shoppingCard == null)
            {
                return Unauthorized();
            }

            if (shoppingCard.Succes == true)
            {
                return Ok(shoppingCard.shoppingCartItem);
            }
            return Ok();
        }

        [HttpPost("change-quantity")]
        public async Task<IActionResult> ChangeQuantity(ChangeQuantityDto changeQuantity)
        {
            var response = await _shoppingCardService.ChangeQuantityAsync(changeQuantity);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpDelete("clear-shopping-cart")]
        public async Task<IActionResult> ClearShoppingCart(int shoppingCartId)
        {
            var response = await _shoppingCardService.DeleteAllProductsFromShoppingCartAsync(shoppingCartId);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("shoppingcartitem")]
        public async Task<IActionResult> DeleteShoppingCartItem(int id)
        {
            var response = await _shoppingCardService.DeleteProductFromShoppingCartAsync(id);
            if (response.Success == true)
            {
                return Ok(response.Id);
            }
            return BadRequest(response.Errors);
        }

        [HttpPost("ShoppingCart")]
        public async Task<IActionResult> PostShoppingCart()
        {
            var response = await _shoppingCardService.AddShoppingCartAsync();
            if (response == null)
            {
                BadRequest();
            }
            return Ok(response);
        }

        [HttpDelete("ShoppingCart")]
        public async Task<IActionResult> PostShoppingCart(int id)
        {
            var response = await _shoppingCardService.DeleteShoppingCartAsync(id);
            if (response == 0)
            {
                BadRequest();
            }
            return Ok(response);
        }

        [HttpPatch("ShoppingCart")]
        public async Task<IActionResult> ChangeActiveShoppingCart(int id)
        {
            var response = await _shoppingCardService.ChangeActiveShoppingCartAsync(id);
            if (response == null)
            {
                BadRequest();
            }
            return Ok(response);
        }

    }
}
