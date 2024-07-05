using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Data;
using ecommerceapi.Dtos;
using ecommerceapi.Helpers;
using ecommerceapi.Interfaces;
using ecommerceapi.Mappers;
using ecommerceapi.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;
        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Task<bool> CheckCategory(int categoryId)
        {
            return _context.Categories.AnyAsync(x => x.Id == categoryId);
        }

        public async Task<Product> CreateProduct(CreateProductDto productDto)
        {
            var productModel = productDto.ToProductFromCreate();
            productModel.Slug = productDto.Name.Replace(" ", "-").ToLower();
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();

            return productModel;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null){
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        
        // public async Task<decimal> GetMaxProductsAsync(){
        //     var max = await _context.Products.FirstOrDefaultAsync(x => x.Price);
            
        //     return max;
        // } 

        public async Task<List<Product>> GetAllProductsAsync(QueryObject query)
        {
            var products = _context.Products.AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.Name)){
                products = products.Where(s => s.Name.Contains(query.Name));
            }
            if(query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase)){
                products = query.IsDescending ? products.OrderByDescending(d => d.Price) : products.OrderBy(d => d.Price);
            }
            if(!string.IsNullOrWhiteSpace(query.Category)){
                products = products.Include(c => c.Category).Where(a => a.Category.Name.Contains(query.Category));
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null){
                return null;
            }
            return product;
        }

        public async Task<Product?> UpdateProduct(int id, UpdateProductDto product)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null){
                return null;
            }
            

            productModel.Name = product.Name;
            productModel.Description = product.Description;
            productModel.Price = product.Price;
            productModel.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
            return productModel;
        }

    }
}