using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;
using NVShop.Core.Models.BaseModels;
using NVShop.Service.DTOs.Customer;
using NVShop.Service.Enums;
using NVShop.Service.Extension;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Service.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        readonly UserManager<BaseUser> _userManager;

        public CustomerService(UserManager<BaseUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<CustomerGetDto>> GetAllAsync()
        {
            var users = _userManager.Users.OfType<Customer>().AsQueryable().AsNoTracking();
            var dtos = await users.Select(customer => customer.ToCustomerGetDto()).ToListAsync();
            return dtos;
        }

        public async Task<CustomerGetDto> GetSingleAsync(string id)
        {
            var user = await _userManager.Users.OfType<Customer>().FirstOrDefaultAsync(c => c.Id == id);
            if (user == null) throw new Exception("Customer not found!");

            return user.ToCustomerGetDto();
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new Customer
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                UserName = dto.Username,
                Birthdate = dto.Birthdate,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return result.Errors.FirstOrDefault().Description;

            var roleResult = await _userManager.AddToRoleAsync(user, RoleName.Customer.ToString());
            if (!roleResult.Succeeded) return roleResult.Errors.FirstOrDefault().Description;
            return $"Customer {user.UserName} was registered successfully!";
        }

        public async Task<string> RemoveAccountAsync(string id)
        {
            var user = await _userManager.Users.OfType<Customer>().FirstOrDefaultAsync(c => c.Id == id);
            if (user == null) return "Customer not found!";

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return result.Errors.FirstOrDefault().Description;
            return $"Customer {user.UserName} was removed successfully!";
        }

        public async Task<string> UpdateAsync(string id, CustomerUpdateDto dto)
        {
            var user = await _userManager.Users.OfType<Customer>().FirstOrDefaultAsync(c => c.Id == id);
            if (user == null) return "Customer not found!";

            user.Firstname = dto.Firstname != null ? dto.Firstname : user.Firstname;
            user.Lastname = dto.Lastname != null ? dto.Lastname : user.Lastname;
            user.Birthdate = dto.Birthdate != null ? (DateOnly)dto.Birthdate : user.Birthdate;

            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return result.Errors.FirstOrDefault().Description;
            return $"Customer {user.UserName} was updated successfully!";
        }
    }
}
