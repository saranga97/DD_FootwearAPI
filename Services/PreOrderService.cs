using System;
using System.Collections.Generic;
using System.Linq;
using DD_FootwearAPI.Models;
using DD_FootwearAPI.Data;

namespace DD_FootwearAPI.Services
{
    public class PreOrderService : IPreOrderService
    {
        private readonly DDContext _context;

        public PreOrderService(DDContext context)
        {
            _context = context;
        }

        public IEnumerable<PreOrder> GetAllPreOrders()
        {
            return _context.PreOrders.ToList();
        }

        public PreOrder GetPreOrderById(int id)
        {
            return _context.PreOrders.Find(id);
        }

        public void CreatePreOrder(PreOrder preOrder)
        {
            _context.PreOrders.Add(preOrder);
            _context.SaveChanges();
        }

        public void UpdatePreOrder(int id, PreOrder preOrder)
        {
            var existingPreOrder = _context.PreOrders.Find(id);
            if (existingPreOrder != null)
            {
                // Update the properties of the existing pre-order
                existingPreOrder.CustomerID = preOrder.CustomerID;
                existingPreOrder.PreOrderedDate = preOrder.PreOrderedDate;
                // Update other properties as needed

                _context.SaveChanges();
            }
        }

        public void DeletePreOrder(int id)
        {
            var preOrder = _context.PreOrders.Find(id);
            if (preOrder != null)
            {
                _context.PreOrders.Remove(preOrder);
                _context.SaveChanges();
            }
        }
    }
}
