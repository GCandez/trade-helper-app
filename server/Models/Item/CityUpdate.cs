using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class ItemUpdate
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}