using EduHome.Areas.Admin.ViewModels.Category;
using EduHome.Areas.Teacher.ViewModels.Course;

namespace EduHome.ViewModels.Course
{
    public class CourseDetailVM
    {
        public ICollection<CategoryGetVM> Categories { get; set; }
        public CourseGetVM Course { get; set; }
    }
}
