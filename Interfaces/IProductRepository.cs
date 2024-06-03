using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos;
using ecommerceapi.Helpers;
using ecommerceapi.Models;

namespace ecommerceapi.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProductsAsync(QueryObject query); 
        public Task<Product?> GetProductById(int id);
        public Task<Product> CreateProduct(CreateProductDto productDto);
        public Task<Product?> UpdateProduct(int id, UpdateProductDto product);
        public Task<Product?> DeleteProduct(int id);
        public Task<bool> CheckCategory(int categoryId);
    }
}