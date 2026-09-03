using EduHome.Models.BaseModels;

namespace EduHome.Models
{
    public class Category : BaseEntity //one terefdir
    {
        public string Name { get; set; }
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>(); //many terefdir 
    }
}
