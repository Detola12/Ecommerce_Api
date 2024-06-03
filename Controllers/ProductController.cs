using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos;
using ecommerceapi.Helpers;
using ecommerceapi.Interfaces;
using ecommerceapi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ecommerceapi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository productRepository)
        {
            _repo = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){
            var products = await _repo.GetAllProductsAsync(query);
            var productDto = products.Select(x => x.ToProductDto());
            return Ok(productDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            var product = await _repo.GetProductById(id);
            if(product == null){
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateProductDto productDto){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var valid = await _repo.CheckCategory(productDto.CategoryId);
            if(!valid){
                return BadRequest("Category does not exist");
            }
            var product = await _repo.CreateProduct(productDto);
            return CreatedAtAction(nameof(GetById), new{id = product.Id}, product.ToProductDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateProductDto productDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var valid = await _repo.CheckCategory(productDto.CategoryId);
            if(!valid){
                return BadRequest("Category does not exist");
            }
            var product = await _repo.UpdateProduct(id, productDto);
            if(product == null){
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id){
            var product = await _repo.DeleteProduct(id);
            return Ok(product);
        }
    }
}