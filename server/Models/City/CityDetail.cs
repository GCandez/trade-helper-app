using System.Collections.Generic;

namespace tradehelperapi.Models
{
    public class CityDetail : CityOverview
    {
        public IEnumerable<int> ShopIds { get; set; } = null!;
    }
}