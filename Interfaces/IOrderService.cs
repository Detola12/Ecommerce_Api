using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApi.Dtos;
using EcommerceApi.Models;

namespace EcommerceApi.Interfaces
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();
        public Task<List<Order>> GetOrdersByUserId(int userId);
        public Task<Order> AddOrder(OrderDto orderDto);

    }
}