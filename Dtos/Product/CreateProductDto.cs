using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(35)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        [Range(1, 1000000000)]
        public decimal Price { get; set;}
        public bool Status { get; set; } = true;
        [Required]
        public int CategoryId { get; set; }

    }
}