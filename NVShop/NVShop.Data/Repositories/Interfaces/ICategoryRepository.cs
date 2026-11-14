using NVShop.Core.Models;
using System.Linq.Expressions;

namespace NVShop.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> AddAsync(Category category);
        IQueryable<Category> GetAll(bool isTracking, params string[] includes);
        IQueryable<Category> GetAllWhere(Expression<Func<Category, bool>> predicate, bool isTracking, params string[] includes);
        Task<Category> GetByIdAsync(int id, bool isTracking, params string[] includes);
        Task<Category> GetWhereAsync(Expression<Func<Category, bool>> predicate, bool isTracking, params string[] includes);
        bool Remove(Category category);
        Task<int> SaveAsync();
        bool Toogle(Category category);
        bool Update(Category category);
    }
}
