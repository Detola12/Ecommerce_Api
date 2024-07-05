using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}