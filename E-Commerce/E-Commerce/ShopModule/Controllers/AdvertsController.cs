using System;
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

namespace E_Commerce.ShopModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        public AdvertsController(DataContext context, IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advert>>> Getadverts()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvert(int id)
        {
            return Ok(await _advertService.GetAdverts());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvert(int id, Advert advert)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Advert>> PostAdvert()
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Advert>> DeleteAdvert(int id)
        {
            return Ok();
        }

    }
}
