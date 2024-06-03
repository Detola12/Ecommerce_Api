using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos.Category
{
    public class CategoryDto
    {
        public int Id{get; set;}
        public string? Name{get; set;}
        public int SubCategory {get; set;} = 0;
        public int? ParentId {get; set;}
        public bool Status {get; set;}
    }
}