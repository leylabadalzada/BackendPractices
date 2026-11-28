using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;
using NVShop.Data.Repositories.Interfaces;
using NVShop.Service.DTOs.Product;
using NVShop.Service.Extension;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Service.Services.Implements
{
    public class ProductService : IProductService
    {
        readonly IGenericRepository<Product> _repository;
        readonly IGenericRepository<Category> _categoryRepository;

        public ProductService(IGenericRepository<Product> repository, IGenericRepository<Category> categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public async Task<string> CreateAsync(ProductCreateDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId, false);
            if (category == null) return $"Category with ID {dto.CategoryId} does not exist";

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _repository.AddAsync(product);
            if (!result) return "Add failed!";
            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed!";
            return $"Product {product.Name} created successfully!";
        }

        public async Task<List<ProductGetDto>> GetAllAsync(bool? isDeleted)
        {
            var query = !isDeleted.HasValue ? _repository.GetAll(false, "Category") :
                _repository.GetAllWhere(p => p.IsDeleted == isDeleted, false, "Category");

            var dtos = await query.Select(product => product.ToProductGetDto()).ToListAsync();
            return dtos;
        }

        public async Task<ProductGetDto> GetSingleAsync(int id, bool? isDeleted)
        {
            var product = !isDeleted.HasValue ? await _repository.GetByIdAsync(id, false, "Category") :
                await _repository.GetWhereAsync(p => p.Id == id && p.IsDeleted == isDeleted, false, "Category");
            if (product == null) throw new Exception("Product not found!");
            var dto = product.ToProductGetDto();
            return dto;
        }

        public async Task<string> RemoveAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id, true);
            if (product == null) return "Product not found!";

            var result = _repository.Remove(product);
            if (!result) return "Remove failed";
            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed!";
            return $"Product {product.Name} removed successfully!";
        }

        public async Task<string> ToggleAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id, true);
            if (product == null) return "Product not found!";

            var result = _repository.Toogle(product);
            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed";
            return result ? $"{product.Name} deleted temporarily!" : $"{product.Name} recovered.";
        }

        public async Task<string> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _repository.GetWhereAsync(p => p.Id == id && !p.IsDeleted, true);
            if (product == null) return "Product not found!";

            product.Name = dto.Name != null ? dto.Name : product.Name;
            product.Stock = dto.Stock != null ? (int)dto.Stock : product.Stock;
            product.Price = dto.Price != null ? (decimal)dto.Price : product.Price;
            product.UpdatedAt = DateTime.UtcNow;

            var result = _repository.Update(product);
            if (!result) return "Updated failed!";

            var count = await _repository.SaveAsync();
            if (count <= 0) return "Save failed!";

            return $"Product {product.Name} updated successfully!";
        }
    }
}
