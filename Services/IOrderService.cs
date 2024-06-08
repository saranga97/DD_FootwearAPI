using System.Collections.Generic;
using DD_FootwearAPI.Models;

namespace DD_FootwearAPI.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(int id, Order order); // Add the 'int id' parameter
        void DeleteOrder(int id);
    }
}
