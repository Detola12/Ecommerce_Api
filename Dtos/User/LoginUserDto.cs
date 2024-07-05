using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceapi.Dtos.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(65)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Password { get; set;} = string.Empty;
    }
}