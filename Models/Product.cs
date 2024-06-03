using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Slug { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public bool Status{get; set;}
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category{ get; set; }
        public DateTime CreatedAt{get; set;} = DateTime.Now;
        public DateTime ModifiedAt{get; set;} = DateTime.Now;
    }
}