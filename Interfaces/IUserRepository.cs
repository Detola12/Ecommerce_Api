using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos.User;
using ecommerceapi.Models;

namespace ecommerceapi.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers();
        public Task<User?> GetById(int id);
        public Task<User> CreateUser(CreateUserDto userDto);
        public Task<User?> UpdateUser(int id, UpdateUserDto userDto);
        public Task<User?> DeleteUser(int id);
        public Task<User?> LoginUser(LoginUserDto loginUser);
        
    }
}