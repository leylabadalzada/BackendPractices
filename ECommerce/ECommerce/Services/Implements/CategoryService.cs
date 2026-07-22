using ECommerce.Contexts;
using ECommerce.Models;
using ECommerce.Services.Interfaces;
using ECommerce.ViewModels.Category;

namespace ECommerce.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        //dependency injection
        private readonly AppDbContext _context; //kuryer, database ile c# arasinda melumat catdirir.

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(CategoryCreateVM vm)
        {
            var category = new Category
            {
                Name = vm.Name,
                CreatedAt = DateTime.UtcNow
            };
            _context.Categories.Add(category);
            //Entity Framework - qeydlerde yazir ki, category deye bir baglama var, o SQL-e sorgu gonderecek, .Add()metodu isletdiyim ucun o, SQL-de Insert into sorgusunu yerine yetirmelidir. Bunun ucun de, baglamani isareleyir. Bunun ucun de EntityState deye bir enum islenir. Onun 5 deyeri var: Added (Insert), Modified (Update), Deleted (Delete), Unchanged(hec bir emr isletmir), Detached (bunu skip edir).
            _context.SaveChanges();
        }

        public List<CategoryGetVM> GetAll()
        {
            var query = _context.Categories.ToList();
            var vms = query.Select(category => new CategoryGetVM
            {
                Name = category.Name,
                Id = category.Id,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            }).ToList();
            return vms;
        }

        public void Remove(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new Exception("Category not found!");
            _context.Remove(category); //Entity Framework EntityState Deleted isareleyir. Yeni SQL-de Delete from sorgusu islensin deye.
            _context.SaveChanges();
        }
    }
}
