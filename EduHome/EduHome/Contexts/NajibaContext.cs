using EduHome.Models;
using EduHome.Models.BaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Contexts
{
    public class NajibaContext : IdentityDbContext<BaseUser, Role, string>
    {
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public NajibaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BaseUser>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Teacher>("teacher")
                .HasValue<AppUser>("user");

            base.OnModelCreating(builder);
        }
    }
}
