using System;
using System.Collections.Generic;
using System.Linq;
using DD_FootwearAPI.Models;
using DD_FootwearAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DD_FootwearAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DDContext _context;

        public ProductService(DDContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductID);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).State = EntityState.Detached; // Detach existing entity
                _context.Products.Update(product); // Attach and update the modified entity
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        // Method to add stock for a product
        public void AddStock(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                product.StockLevel += quantity; // Increase stock level
                _context.SaveChanges();
            }
        }

        // Method to deduct stock for a product
        public void DeductStock(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                if (product.StockLevel >= quantity)
                {
                    product.StockLevel -= quantity; // Deduct stock level
                    _context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Insufficient stock");
                }
            }
        }
    }
}
