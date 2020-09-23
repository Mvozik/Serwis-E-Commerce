using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Core.Data;
using E_Commerce.Core.Entities;
using Mapster;

namespace ShopModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly DataContext _context;

        public AdvertsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advert>>> Getadverts()
        {
            return await _context.adverts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Advert>> GetAdvert(int id)
        {
            var advert = await _context.adverts.FindAsync(id);

            if (advert == null)
            {
                return NotFound();
            }

            return advert;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvert(int id, Advert advert)
        {
            if (id != advert.Id)
            {
                return BadRequest();
            }

            _context.Entry(advert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Advert>> PostAdvert(PostAdvertDto advert)
        {
            var advert2 = advert.Adapt<Advert>();
            _context.adverts.Add(advert2);
            await _context.SaveChangesAsync();
            return Ok(advert2);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Advert>> DeleteAdvert(int id)
        {
            var advert = await _context.adverts.FindAsync(id);
            if (advert == null)
            {
                return NotFound();
            }

            _context.adverts.Remove(advert);
            await _context.SaveChangesAsync();

            return advert;
        }

        private bool AdvertExists(int id)
        {
            return _context.adverts.Any(e => e.Id == id);
        }
    }
}
