using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class ShopCreation
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CityId { get; set; }
    }
}