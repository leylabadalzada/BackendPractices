using Microsoft.AspNetCore.Identity;

namespace EduHome.Models.BaseModels
{
    public class BaseUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
