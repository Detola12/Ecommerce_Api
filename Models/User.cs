using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ecommerceapi.Models
{
    [Index("PhoneNumber",IsUnique = true)]
    [Index("Email",IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string FirstName { get; set;} = string.Empty;
        [StringLength(30)]
        public string LastName { get; set;} = string.Empty;
        [StringLength(13)]
        public string PhoneNumber { get; set;} = string.Empty;
        [EmailAddress]
        public string Email { get; set;} = string.Empty;
    }
}