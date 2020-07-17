using System.Collections.Generic;

namespace tradehelperapi.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual City City { get; set; } = null!;
        public virtual List<Listing> Listings { get; set; } = null!;

        public Shop()
        {
            Listings = new List<Listing>();
        }
    }
}