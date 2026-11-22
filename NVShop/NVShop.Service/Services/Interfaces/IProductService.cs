using NVShop.Service.DTOs.Product;

namespace NVShop.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<string> CreateAsync(ProductCreateDto dto);
        Task<List<ProductGetDto>> GetAllAsync(bool? isDeleted);
        Task<ProductGetDto> GetSingleAsync(int id, bool? isDeleted);
        Task<string> RemoveAsync(int id);
        Task<string> ToggleAsync(int id);
        Task<string> UpdateAsync(int id, ProductUpdateDto dto);
    }
}
