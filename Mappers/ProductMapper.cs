using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos;
using ecommerceapi.Models;

namespace ecommerceapi.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProductFromCreate(this CreateProductDto productDto){
            return new Product{
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
                Status = productDto.Status,
            };
        }
        public static Product ToProductFromUpdate(this UpdateProductDto productDto){
            return new Product{
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
            };
        }

        public static ProductDto ToProductDto(this Product product){
            return new ProductDto{
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
            };
        }
    }
}