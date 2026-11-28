using NVShop.Service.Enums;

namespace NVShop.Service.DTOs.Role
{
    public record RoleCreateDto
    {
        public RoleName Name { get; set; }
        public string Description { get; set; }
    }
}
