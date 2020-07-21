using System;
using System.Collections.Generic;

namespace tradehelperapi.Models
{
    public class ListingDetail : ListingOverview
    {
        public class HistoryDetail
        {
            public long Id { get; set; }
            public decimal Price { get; set; }
            public uint Stock { get; set; }
            public DateTime Date { get; set; }
        }

        public IEnumerable<HistoryDetail> History { get; set; } = null!;
    }
}