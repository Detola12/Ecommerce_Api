using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Dtos;
using EcommerceApi.Models;

namespace EcommerceApi.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrderModel(this OrderDto orderDto){
            return new Order{
                ProductId = orderDto.ProductId,
                UserId = orderDto.UserId,
                Quantity = orderDto.Quantity,
            };
        }
    }
}