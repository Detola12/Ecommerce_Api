using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos.Category;
using ecommerceapi.Models;

namespace ecommerceapi.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToCategoryFromCreateCategoryDto(this CreateCategoryDto categoryDto){
            if(categoryDto.ParentId == 0){
                categoryDto.ParentId = null;
            }
            return new Category{
                Name = categoryDto.Name,
                ParentId = categoryDto.ParentId,
                Status = categoryDto.Status,
            };
        }

        public static CategoryDto ToCategoryDto(this Category category){
            return new CategoryDto{
                Id = category.Id,
                Name = category.Name,
                SubCategory = category.SubCategory,
                ParentId = category.ParentId,
                Status = category.Status,
            };
        }
            
        
    }
}