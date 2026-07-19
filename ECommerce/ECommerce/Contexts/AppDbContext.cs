using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
