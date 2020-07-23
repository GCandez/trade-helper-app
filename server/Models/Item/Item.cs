using System.Collections.Generic;

namespace tradehelperapi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Listing> Listings { get; set; } = null!;

        public Item()
        {
            Listings = new List<Listing>();
        }
    }
}