using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Dtos.User;
using ecommerceapi.Models;

namespace ecommerceapi.Mappers
{
    public static class UserMapper
    {
        public static User ToUserModel(this CreateUserDto userDto){
            return new User{
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Password = userDto.Password,
            };
        }

        public static UserDto UserToDto(this UserDto userDto){
            return new UserDto{
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
            };
        }

        public static UserDto UserToUserDto(this User user){
            return new UserDto{
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public static User FromUpdateDtoToUser(this UpdateUserDto userDto){
            return new User{
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Password = userDto.Password,
                LastModifiedAt = DateTime.Now 
            };
        }
    }
}