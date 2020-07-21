using System;
using System.ComponentModel.DataAnnotations;

namespace tradehelperapi.Models
{
    public class ListingCreation
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal InitialPrice { get; set; }

        [Required]
        public uint InitialStock { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}