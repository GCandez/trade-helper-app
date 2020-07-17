using System.Collections.Generic;

namespace tradehelperapi.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Shop> Shops { get; set; }

        public City()
        {
            Shops = new List<Shop>();
        }
    }
}