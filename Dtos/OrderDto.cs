using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Dtos
{
    public class OrderDto
    {
        public int ProductId { get; set; }
        public int Quantity {get; set;}
        public int UserId {get; set;}
    }
}