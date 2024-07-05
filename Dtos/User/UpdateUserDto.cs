using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos.User
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set;} = string.Empty;
        [Required]
        [MaxLength(30)]
        public string LastName { get; set;} = string.Empty;
        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set;} = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(65)]
        public string Email { get; set;} = string.Empty;
        [Required]
        [MaxLength(25)]
        public string Password { get; set;} = string.Empty;
    }
}