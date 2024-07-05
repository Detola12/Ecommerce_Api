using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ecommerceapi.Dtos.User;
using ecommerceapi.Interfaces;
using ecommerceapi.Mappers;
using EcommerceApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace ecommerceapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository repo;
        private readonly IConfiguration configuration;
        private readonly IAuthService authService;
        public UserController(
            IUserRepository repository, ILogger<UserController> logger, IConfiguration configuration, IAuthService authService
            ){
            repo = repository;
            _logger = logger;
            this.configuration = configuration;
            this.authService = authService;
        }
        
        // [Authorize(Policy = "IsAdmin")]
        [HttpGet]
        [Route("getAllUser")]
        public async Task<IActionResult> GetAllUser(){
            var user = await repo.GetAllUsers();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserId([FromRoute] int id)
        {
            var user = await repo.GetById(id);
            if (user == null){
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto userDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            try{
                var user = await repo.CreateUser(userDto);
                authService.GenerateToken(user);
                return CreatedAtAction(nameof(GetUserId), new{id = user.Id}, userDto);
            }
            catch(DbUpdateException ex){
                if(ex.InnerException is MySqlException e && (e.Number == 1062)){
                    if(e.Message.Contains("Email") && e.Message.Contains("Phone")){
                        return BadRequest("Email and Phone Number already exists");
                    }
                    else if(e.Message.Contains("Email")){
                        return BadRequest("Email already exists");
                    }
                    return BadRequest("Phone Number already exist");
                }
                return BadRequest(ex.Message);
            }
            
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto userDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user = await repo.LoginUser(userDto);
            if(user == null){
                return Unauthorized("Invalid Login Details");
            }

            
            var token = authService.GenerateToken(user);
            return Ok( new{ Token = token , User = user.UserToUserDto()} );
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id,[FromBody] UpdateUserDto userDto)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            try{
                await repo.UpdateUser(id, userDto);
                return Ok(userDto);
            }
            
            catch(DbUpdateException ex){
                if(ex.InnerException is MySqlException e && (e.Number == 1062)){
                    if(e.Message.Contains("Email")){
                        return BadRequest("Email already exists");
                    }
                    return BadRequest("Phone Number already exist");
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id){
            var user = await repo.DeleteUser(id);
            return Ok(user);
        }

        
    }
}