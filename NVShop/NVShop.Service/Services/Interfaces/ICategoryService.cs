using NVShop.Service.DTOs.Category;

namespace NVShop.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<string> CreateAsync(CategoryCreateDto dto);
        Task<List<CategoryGetDto>> GetAllAsync(bool? isDeleted);
        Task<CategoryGetDto> GetSingleAsync(int id, bool? isDeleted);
        Task<string> RemoveAsync(int id);
        Task<string> ToggleAsync(int id);
        Task<string> UpdateAsync(int id, CategoryUpdateDto dto);
    }
}
