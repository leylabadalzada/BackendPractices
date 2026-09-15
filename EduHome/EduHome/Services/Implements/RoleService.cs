using EduHome.Areas.Admin.ViewModels.Role;
using EduHome.Models;
using EduHome.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Services.Implements
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Create(RoleCreateVM vm)
        {
            var role = new Role
            {
                Name = vm.Name,
                Description = vm.Description
            };

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded) throw new Exception("Create role failed");
        }

        public async Task<List<RoleGetVM>> GetAll()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var vms = roles.Select(role => new RoleGetVM
            {
                Id = role.Id,
                Description = role.Description,
                Name = role.Name
            }).ToList();
            return vms;
        }

        public async Task Remove(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) throw new Exception("Role not found!");

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) throw new Exception("Remove failed");
        }
    }
}
