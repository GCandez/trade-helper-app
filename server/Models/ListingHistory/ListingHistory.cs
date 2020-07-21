using System;

namespace tradehelperapi.Models
{
    public class ListingHistory
    {
        public long Id { get; set; }
        public virtual Listing Listing { get; set; } = null!;
        public decimal Price { get; set; }
        public uint Stock { get; set; }
        public DateTime Date { get; set; }
    }
}