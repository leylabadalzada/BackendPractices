using NVShop.Core.Models;
using NVShop.Service.DTOs.Category;
using NVShop.Service.DTOs.Customer;
using NVShop.Service.DTOs.Product;
using NVShop.Service.DTOs.Role;

namespace NVShop.Service.Extension
{
    public static class Mapping
    {
        public static CategoryGetDto ToCategoryGetDto(this Category category) =>
            new CategoryGetDto
            {
                Name = category.Name,
                Id = category.Id,
                CreatedAt = category.CreatedAt,
                DeletedAt = category.DeletedAt,
                IsDeleted = category.IsDeleted,
                UpdatedAt = category.UpdatedAt
            };

        public static ProductGetDto ToProductGetDto(this Product product) =>
            new ProductGetDto
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                CreatedAt = product.CreatedAt,
                DeletedAt = product.DeletedAt,
                IsDeleted = product.IsDeleted,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                UpdatedAt = product.UpdatedAt,
                CategoryName = product.Category.Name
            };

        public static RoleGetDto ToRoleGetDto(this Role role) =>
            new RoleGetDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };

        public static CustomerGetDto ToCustomerGetDto(this Customer customer) =>
            new CustomerGetDto
            {
                Id = customer.Id,
                Birthdate = customer.Birthdate,
                Email = customer.Email,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Username = customer.UserName,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };
    }
}
