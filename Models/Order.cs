using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Models;

namespace EcommerceApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity {get; set;}
        public int UserId {get; set;}
        public DateTime OrderDate {get; set;} = DateTime.Now;
        [ForeignKey("ProductId")]
        public Product? Product{ get; set; }
        [ForeignKey("UserId")]
        public User? User{ get; set; }
    }
}