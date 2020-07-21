using System.Collections.Generic;

namespace tradehelperapi.Models
{
    public class ItemDetail : ItemOverview
    {
        public IEnumerable<int> ListingIds { get; set; } = null!;
    }
}