using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string? Name{get; set;}
        public int? ParentId{get; set;}
        public bool Status {get; set;}
    }
}