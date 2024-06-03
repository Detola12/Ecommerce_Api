using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Data;
using ecommerceapi.Dtos.Category;
using ecommerceapi.Interfaces;
using ecommerceapi.Mappers;
using ecommerceapi.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceContext _context;

        public CategoryRepository(EcommerceContext context)
        {
            _context = context;
        }


        public async Task<Category> CreateCategoryAsync(Category category)
        {
           
        
            await _context.Categories.AddAsync(category);
            if(await _context.Categories.AnyAsync(c => c.Id == category.ParentId)){
                var parentCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.ParentId);
                if(parentCategory != null){
                    parentCategory.SubCategory += 1;
                }   
            }
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null){
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;

        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var category = await _context.Categories.ToListAsync();
            return category;
            
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(category == null){
                return null;
            }
            category.Name = categoryDto.Name;
            category.Status = categoryDto.Status;

            await _context.SaveChangesAsync();
            return category;
        }

    }
}