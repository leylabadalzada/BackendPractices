using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;
using NVShop.Core.Models.BaseModels;

namespace NVShop.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<BaseUser, Role, string>
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public AppDbContext(DbContextOptions opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BaseUser>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Customer>("customer");

            base.OnModelCreating(modelBuilder);
        }
    }
}
