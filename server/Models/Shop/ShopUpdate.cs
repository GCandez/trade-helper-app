using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class ShopUpdate
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}