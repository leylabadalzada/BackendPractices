using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;
using NVShop.Service.DTOs.Role;
using NVShop.Service.Extension;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Service.Services.Implements
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<string> CreateAsync(RoleCreateDto dto)
        {
            var role = new Role
            {
                Name = dto.Name.ToString(),
                Description = dto.Description
            };

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded) return $"{result.Errors.FirstOrDefault().Description}";
            return $"{role.Name} created successfully!";
        }

        public async Task<List<RoleGetDto>> GetAllAsync()
        {
            var roles = _roleManager.Roles.AsQueryable().AsNoTracking();
            var dtos = await roles.Select(role => role.ToRoleGetDto()).ToListAsync();
            return dtos;
        }

        public async Task<RoleGetDto> GetSingleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) throw new Exception("Role not found!");

            return role.ToRoleGetDto();
        }

        public async Task<string> RemoveAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return "Role not found!";

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) return result.Errors.FirstOrDefault().Description;

            return $"{role.Name} was removed successfully!";
        }
    }
}
