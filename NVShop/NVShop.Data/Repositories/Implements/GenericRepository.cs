using Microsoft.EntityFrameworkCore;
using NVShop.Core.Models.BaseModels;
using NVShop.Data.Contexts;
using NVShop.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NVShop.Data.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            var entry = await _context.AddAsync(model);
            return entry.State == EntityState.Added;
        }

        public IQueryable<T> GetAll(bool isTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
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

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = Table.Where(predicate).AsQueryable();
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

        public async Task<T> GetByIdAsync(int id, bool isTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking) query.AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var model = await query.FirstOrDefaultAsync(c => c.Id == id);
            return model;
        }

        public async Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking) query.AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var model = await query.FirstOrDefaultAsync(predicate);
            return model;
        }

        public bool Remove(T model)
        {
            var entry = _context.Remove(model);
            return entry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Toogle(T model)
        {
            model.IsDeleted = !model.IsDeleted;
            model.DeletedAt = DateTime.UtcNow;
            _context.Update(model);
            return model.IsDeleted;
        }

        public bool Update(T model)
        {
            var entry = _context.Update(model);
            return entry.State == EntityState.Modified;
        }
    }
}
