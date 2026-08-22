using EduHome.Models;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Contexts
{
    public class NajibaContext : DbContext
    {
        public DbSet<Slider> sliders { get; set; }
        public NajibaContext(DbContextOptions options) : base(options)
        {
        }
    }
}
