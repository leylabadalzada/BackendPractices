using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;
using NVShop.Data.Repositories.Interfaces;
using NVShop.Service.DTOs.Category;
using NVShop.Service.Extension;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Service.Services.implements
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateAsync(CategoryCreateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _repository.AddAsync(category);
            if (!result) return "Add failed!";

            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed!";

            return $"Category - {dto.Name} created successfully!";
        }

        public async Task<string> RemoveAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id, true);
            if (category == null) return "Category not found!";

            var result = _repository.Remove(category);
            if (!result) return "Remove failed!";
            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed!";

            return $"{category.Name} removed successfully!";
        }

        public async Task<List<CategoryGetDto>> GetAllAsync(bool? isDeleted)
        {
            var query = !isDeleted.HasValue ? _repository.GetAll(false) : _repository.GetAllWhere(c => c.IsDeleted == isDeleted, false);
            var dtos = await query.Select(category => category.ToCategoryGetDto()).ToListAsync();
            return dtos;
        }

        public async Task<string> ToggleAsync(int id) //deletesoft
        {
            var category = await _repository.GetByIdAsync(id, true);
            if (category == null) return "Category not found!";

            var result = _repository.Toogle(category);
            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed!";

            return result ? $"{category.Name} deleted temporarily!" : $"{category.Name} recovered.";
        }

        public async Task<string> UpdateAsync(int id, CategoryUpdateDto dto)
        {
            var category = await _repository.GetByIdAsync(id, true);
            if (category == null) return "Category not found!";

            category.Name = dto.Name != null ? dto.Name : category.Name;
            category.UpdatedAt = DateTime.UtcNow;

            var result = _repository.Update(category);
            if (!result) return "Update failed!";

            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed";

            return $"{category.Name} updated successfully!";
        }

        public async Task<CategoryGetDto> GetSingleAsync(int id, bool? isDeleted)
        {
            var category = !isDeleted.HasValue ? await _repository.GetByIdAsync(id, false) :
                await _repository.GetWhereAsync(c => c.Id == id && c.IsDeleted == isDeleted, false);
            if (category == null) throw new Exception("Category not found");
            return category.ToCategoryGetDto();
        }
    }
}
