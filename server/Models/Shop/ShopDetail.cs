using System.Collections.Generic;
using System.Linq;

namespace tradehelperapi.Models
{
    public class ShopDetail : ShopOverview
    {
        public int CityId { get; set; }
        public IEnumerable<int> ListingIds { get; set; } = null!;
    }
}