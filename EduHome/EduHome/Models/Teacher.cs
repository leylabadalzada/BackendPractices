using EduHome.Models.BaseModels;

namespace EduHome.Models
{
    public class Teacher : BaseUser
    {
        public string Description { get; set; }
        public string Speciality { get; set; }
        public string Image { get; set; }
        public string Degree { get; set; }
        public byte ExperienceInYear { get; set; }
        public string Faculty { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
