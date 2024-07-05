using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceapi.Data;
using EcommerceApi.Dtos;
using EcommerceApi.Interfaces;
using EcommerceApi.Mappers;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly EcommerceContext _context;
        public OrderService(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(OrderDto orderDto)
        {
            var orderModel = orderDto.ToOrderModel();
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await _context.Orders.Include(x => x.User).Where(a => a.UserId == userId).ToListAsync();
        
        }
    }
}