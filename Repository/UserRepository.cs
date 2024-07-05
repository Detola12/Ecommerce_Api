using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Data;
using ecommerceapi.Dtos.User;
using ecommerceapi.Interfaces;
using ecommerceapi.Mappers;
using ecommerceapi.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceContext _context;
        public UserRepository(EcommerceContext context){
            _context = context;
        }
        public async Task<User> CreateUser(CreateUserDto userDto)
        {
            var userModel = userDto.ToUserModel();
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async  Task<User?> DeleteUser(int id)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null){
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null){
                return null;
            }
            return user;
        }

        public async Task<User?> LoginUser(LoginUserDto loginUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginUser.Email && x.Password == loginUser.Password);
            if(user == null){
                return null;
            }
            return user;
        }

        public async Task<User?> UpdateUser(int id, UpdateUserDto userDto)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null){
                return null;
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Password = userDto.Password;

            await _context.SaveChangesAsync();
            return user;
            
        }
    }
}