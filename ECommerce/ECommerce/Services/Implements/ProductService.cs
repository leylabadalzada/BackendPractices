using ECommerce.Contexts;
using ECommerce.Models;
using ECommerce.Services.Interfaces;
using ECommerce.ViewModels.Product;

namespace ECommerce.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(ProductCreateVM vm)
        {
            var category = _context.Categories.Find(vm.CategoryId);
            if (category == null) throw new Exception("Category not found!");
            var product = new Product
            {
                Name = vm.Name,
                Description = vm.Description,
                Client = vm.Client,
                Date = vm.Date,
                Price = vm.Price,
                URL = vm.URL,
                CreatedAt = DateTime.UtcNow,
                CategoryId = category.Id
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<ProductGetVM> GetAll()
        {
            var query = _context.Products.ToList();
            var vms = query.Select(product => new ProductGetVM
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Client = product.Client,
                CreatedAt = product.CreatedAt,
                Date = product.Date,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                UpdatedAt = product.UpdatedAt,
                URL = product.URL
            }).ToList();
            return vms;
        }

        public ProductGetVM GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new Exception("Product not found!");
            var vm = new ProductGetVM
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Client = product.Client,
                CreatedAt = product.CreatedAt,
                Date = product.Date,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                UpdatedAt = product.UpdatedAt,
                URL = product.URL
            };
            return vm;
        }

        public void Remove(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new Exception("Product not found!");
            _context.Remove(product);
            _context.SaveChanges();
        }

        public void Update(int id, ProductUpdateVM vm)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new Exception("Product not found!");
            product.Name = vm.Name;
            product.Client = vm.Client;
            product.URL = vm.URL;
            product.Price = vm.Price;
            product.Description = vm.Description;
            product.Date = vm.Date;
            product.UpdatedAt = DateTime.UtcNow;
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
