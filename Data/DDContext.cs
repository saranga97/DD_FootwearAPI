using Microsoft.EntityFrameworkCore;
using DD_FootwearAPI.Models;

namespace DD_FootwearAPI.Data
{
    public class DDContext : DbContext
    {
        public DDContext(DbContextOptions<DDContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PreOrder> PreOrders { get; set; }
    }
}
