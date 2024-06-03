using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos.Category;
using ecommerceapi.Models;

namespace ecommerceapi.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category?> GetCategoryByIdAsync(int id);
        public Task<Category> CreateCategoryAsync(Category category);
        public Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
        public Task<Category?> DeleteCategory(int id);


    }
}