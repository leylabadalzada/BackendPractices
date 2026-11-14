using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models;
using NVShop.Data.Contexts;
using NVShop.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NVShop.Data.Repositories.Implements
{
    public class CatergoryRepository : ICategoryRepository
    {
        readonly AppDbContext _context;

        public CatergoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Category category)
        {
            var entry = await _context.AddAsync(category);
            return entry.State == EntityState.Added;
        }

        public bool Remove(Category category)
        {
            var entry = _context.Remove(category);
            return entry.State == EntityState.Deleted;
        }

        public bool Update(Category category)
        {
            var entry = _context.Update(category);
            return entry.State == EntityState.Modified;
        }

        public bool Toogle(Category category)
        {
            category.IsDeleted = !category.IsDeleted;
            category.DeletedAt = DateTime.UtcNow;
            _context.Update(category);
            return category.IsDeleted;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<Category> GetAll(bool isTracking, params string[] includes)
        {
            var query = _context.categories.AsQueryable();
            if (!isTracking) query.AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public IQueryable<Category> GetAllWhere(Expression<Func<Category, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = _context.categories.Where(predicate).AsQueryable();
            if (!isTracking) query.AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async Task<Category> GetByIdAsync(int id, bool isTracking, params string[] includes)
        {
            var query = _context.categories.AsQueryable();
            if (!isTracking) query.AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var category = await query.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Category> GetWhereAsync(Expression<Func<Category, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = _context.categories.AsQueryable();
            if (!isTracking) query.AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var category = await query.FirstOrDefaultAsync(predicate);
            return category;
        }
    }
}
