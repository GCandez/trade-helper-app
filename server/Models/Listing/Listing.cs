using System;
using System.Collections.Generic;
using System.Linq;

namespace tradehelperapi.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public virtual Shop Shop { get; set; } = null!;
        public virtual Item Item { get; set; } = null!;
        public virtual List<ListingHistory> History { get; set; } = null!;

        public decimal CurrentPrice => this.History.LastOrDefault().Price;
        public uint CurrentStock => History.LastOrDefault().Stock;
        public DateTime LastUpdate => History.LastOrDefault().Date;
    }
}