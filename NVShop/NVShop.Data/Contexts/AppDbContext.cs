using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;

namespace NVShop.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public AppDbContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}
