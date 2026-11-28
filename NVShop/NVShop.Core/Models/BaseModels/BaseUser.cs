using Microsoft.AspNetCore.Identity;

namespace NVShop.Core.Models.BaseModels
{
    public class BaseUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
