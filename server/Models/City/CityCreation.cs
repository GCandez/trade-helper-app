using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class CityCreation
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}