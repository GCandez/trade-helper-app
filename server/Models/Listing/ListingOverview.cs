using System;

namespace tradehelperapi.Models
{
    public class ListingOverview
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int ItemId { get; set; }
        public decimal CurrentPrice { get; set; }
        public uint CurrentStock { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}