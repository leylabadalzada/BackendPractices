using NVShop.Service.DTOs.Role;

namespace NVShop.Service.Services.Interfaces
{
    public interface IRoleService
    {
        Task<string> CreateAsync(RoleCreateDto dto);
        Task<string> RemoveAsync(string id);
        Task<List<RoleGetDto>> GetAllAsync();
        Task<RoleGetDto> GetSingleAsync(string id);
    }
}
