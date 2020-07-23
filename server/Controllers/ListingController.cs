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
    [Route("api/listings")]
    public class ListingController : ControllerBase
    {
        private DatabaseContext _context;

        public ListingController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ListingOverview>>> All()
        {
            var listings = await _context.Listings.ToListAsync();
            return listings.Select(l => new ListingOverview
            {
                Id = l.Id,
                ShopId = l.Shop.Id,
                ItemId = l.Item.Id,
                CurrentPrice = l.CurrentPrice,
                CurrentStock = l.CurrentStock,
                LastUpdate = l.LastUpdate
            }).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListingDetail>> Find(int id)
        {
            var listing = await _context.Listings.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }

            return Ok(new ListingDetail
            {
                Id = listing.Id,
                ShopId = listing.Shop.Id,
                ItemId = listing.Item.Id,
                CurrentPrice = listing.CurrentPrice,
                CurrentStock = listing.CurrentStock,
                History = listing.History.Select(h => new ListingDetail.HistoryDetail
                {
                    Id = h.Id,
                    Price = h.Price,
                    Stock = h.Stock,
                    Date = h.Date
                })

            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListingDetail>> Create(ListingCreation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _context.Items.FindAsync(model.ItemId);

            if (item == null)
            {
                ModelState.AddModelError("itemId", "No item with with given id was found");
                return BadRequest(ModelState);
            }

            var shop = await _context.Shops.FindAsync(model.ShopId);

            if (shop == null)
            {
                ModelState.AddModelError("shopId", "No shop with given id was found");
                return BadRequest(ModelState);
            }

            var listing = new Listing
            {
                Shop = shop,
                Item = item,
                History = new List<ListingHistory>()
            };

            listing.History.Add(new ListingHistory
            {
                Listing = listing,
                Price = model.InitialPrice,
                Stock = model.InitialStock,
                Date = model.Date,
            });

            _context.Add(listing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Find), new { id = listing.Id }, new ListingDetail
            {
                Id = listing.Id,
                ShopId = listing.Shop.Id,
                ItemId = listing.Item.Id,
                CurrentPrice = listing.CurrentPrice,
                CurrentStock = listing.CurrentStock,
                History = listing.History.Select(h => new ListingDetail.HistoryDetail
                {
                    Id = h.Id,
                    Price = h.Price,
                    Stock = h.Stock,
                    Date = h.Date
                })

            });
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, CityUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            city.Name = model.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var listing = await _context.Listings.FindAsync(id);

            if (listing == null)
            {
                return NotFound();
            }

            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
