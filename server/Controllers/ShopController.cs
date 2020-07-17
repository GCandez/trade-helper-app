using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tradehelperapi.Models;

namespace tradehelperapi.Controllers
{
    [ApiController]
    [Route("shops")]
    public class ShopController : ControllerBase
    {
        private DatabaseContext _context;

        public ShopController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ShopOverview>>> All()
        {
            var shops = await _context.Shops.ToListAsync();
            return shops.Select(c => new ShopOverview
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShopDetail>> Find(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(new ShopDetail
            {
                Id = shop.Id,
                Name = shop.Name,
                CityId = shop.City.Id,
                ListingIds = shop.Listings.Select(l => l.Id)
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShopDetail>> Create(ShopCreation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = await _context.Cities.FindAsync(model.CityId);

            if (city == null)
            {
                ModelState.AddModelError("cityId", "No city with given id was found.");
                return BadRequest(ModelState);
            }

            var shop = new Shop
            {
                Name = model.Name,
                City = city
            };

            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Find), new { id = shop.Id }, new ShopDetail
            {
                Id = shop.Id,
                Name = shop.Name,
                CityId = shop.City.Id,
                ListingIds = shop.Listings.Select(l => l.Id)
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, ShopUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            shop.Name = model.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var shop = await _context.Shops.FindAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
