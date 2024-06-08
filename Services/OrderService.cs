using System;
using System.Collections.Generic;
using System.Linq;
using DD_FootwearAPI.Models;
using DD_FootwearAPI.Data;
using Microsoft.Extensions.Logging;

namespace DD_FootwearAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly DDContext _context;
        private readonly ILogger<OrderService> _logger; // Injected logger

        public OrderService(DDContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void CreateOrder(Order order)
        {
            try
            {
                // Check if product has sufficient stock
                var product = _context.Products.Find(order.ProductID);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not found");
                }

                if (product.StockLevel < order.Quantity)
                {
                    throw new InvalidOperationException("Insufficient stock for the product");
                }

                // Deduct stock level
                product.StockLevel -= order.Quantity;

                // Add the order
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while placing the order");
                throw; // Re-throw the exception after logging
            }
        }

        public void UpdateOrder(int id, Order order)
        {
            var existingOrder = _context.Orders.Find(id);
            if (existingOrder != null)
            {
                // Update the properties of the existing order
                existingOrder.Quantity = order.Quantity;
                existingOrder.OrderStatus = order.OrderStatus;
                // Update other properties as needed

                _context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
