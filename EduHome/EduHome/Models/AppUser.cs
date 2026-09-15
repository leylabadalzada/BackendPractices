using EduHome.Models.BaseModels;

namespace EduHome.Models
{
    public class AppUser : BaseUser
    {
        public DateOnly BirthDate { get; set; }
        public string University { get; set; }
    }
}
