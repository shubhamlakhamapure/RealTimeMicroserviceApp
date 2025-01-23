﻿using System.ComponentModel.DataAnnotations;

namespace Product.API.DTO
{
    public class ProductDTO
    {
        public int iProduct { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
