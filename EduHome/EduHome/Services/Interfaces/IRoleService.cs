using EduHome.Areas.Admin.ViewModels.Role;

namespace EduHome.Services.Interfaces
{
    public interface IRoleService
    {
        Task Create(RoleCreateVM vm);
        Task Remove(string id);
        Task<List<RoleGetVM>> GetAll();
    }
}
