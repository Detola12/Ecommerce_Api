using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Dtos.Payment
{
    public class PaymentDto
    {
        public decimal amount {get; set;}
        public string email {get; set;} = string.Empty;
    }
}