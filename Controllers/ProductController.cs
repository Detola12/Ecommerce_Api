using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos;
using ecommerceapi.Helpers;
using ecommerceapi.Interfaces;
using ecommerceapi.Mappers;
using EcommerceApi.Dtos.Payment;
using EcommerceApi.Services;
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

        // [HttpGet]
        // [Route("AddProduct/{id}")]
        // public async Task<IActionResult> AddProductToCart([FromRoute] int id){
        //     var cart = await _repo.GetProductById(id);
        //     new Cookie
        // }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto){

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
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto productDto){
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
        public async Task<IActionResult> DeleteProduct([FromRoute] int id){
            var product = await _repo.DeleteProduct(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("payment")]
        public async Task<IActionResult> Payment([FromBody] PaymentDto paymentDto){
            var pay = new FlutterwaveService();
            var response = await pay.MakePayment(paymentDto.amount, paymentDto.email, "https://webhook.site/f0678f68-2845-45ed-a739-3ea0376ea92b");
            return Ok(response);
        }
    }
}