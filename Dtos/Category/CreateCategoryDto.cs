using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos.Category
{
    public class CreateCategoryDto
    {
        
        public string Name{get; set;} = string.Empty;
        public int? ParentId{get; set;} = 0;
        public bool Status{get; set;} = false;
    }
}