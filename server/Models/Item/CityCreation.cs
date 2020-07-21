using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class ItemCreation
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}