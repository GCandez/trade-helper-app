using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class CityUpdate
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}