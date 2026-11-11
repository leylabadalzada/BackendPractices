using NVShop.Service.DTOs.Category;

namespace NVShop.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<string> CreateAsync(CategoryCreateDto dto);
    }
}
