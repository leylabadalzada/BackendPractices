using NVShop.Core.Models;

namespace NVShop.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> AddAsync(Category category);
        IQueryable<Category> GetAll(bool isTracking, params string[] includes);
        Task<Category> GetByIdAsync(int id, bool isTracking, params string[] includes);
        bool Remove(Category category);
        Task<int> SaveAsync();
        bool Toogle(Category category);
        bool Update(Category category);
    }
}
