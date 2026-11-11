using NVShop.Core.Models;
using NVShop.Data.Repositories.Interfaces;
using NVShop.Service.DTOs.Category;
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
    }
}
