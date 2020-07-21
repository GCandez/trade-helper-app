using System;
using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class ListingUpdate
    {
        [Required]
        public uint Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}