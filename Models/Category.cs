using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Models
{
    public class Category
    {
        public int Id{get; set;}
        [MinLength(3)]
        [StringLength(30)]
        public string Name{get; set;} = string.Empty;
        public int SubCategory {get; set;} = 0;
        public int? ParentId {get; set;}
        public bool Status {get; set;} = false;
        public DateTime CreatedAt{get; set;} = DateTime.Now;
        public DateTime LastUpdatedAt{get; set; } = DateTime.Now;
        [ForeignKey("ParentId")]
        public Category? Parent{get; set;}
        // public List<Product> Products {get; set;} = new List<Product>();
    }
}