using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos.User
{
    public class UserDto
    {
        [MaxLength(30)]
        public string FirstName { get; set;} = string.Empty;
        [MaxLength(30)]
        public string LastName { get; set;} = string.Empty;
        [MaxLength(13)]
        public string PhoneNumber { get; set;} = string.Empty;
        [EmailAddress]
        [MaxLength(65)]
        public string Email { get; set;} = string.Empty;
    }
}