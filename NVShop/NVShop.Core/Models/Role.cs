using Microsoft.AspNetCore.Identity;

namespace NVShop.Core.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
