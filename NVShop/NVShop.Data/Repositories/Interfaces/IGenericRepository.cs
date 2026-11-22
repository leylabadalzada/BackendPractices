using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models.BaseModels;
using System.Linq.Expressions;

namespace NVShop.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        IQueryable<T> GetAll(bool isTracking, params string[] includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes);
        Task<T> GetByIdAsync(int id, bool isTracking, params string[] includes);
        Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes);
        bool Remove(T model);
        Task<int> SaveAsync();
        bool Toogle(T model);
        bool Update(T model);
        DbSet<T> Table { get; }
    }
}
