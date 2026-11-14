using NVShop.Core.Models;
using NVShop.Service.DTOs.Category;

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
    }
}
