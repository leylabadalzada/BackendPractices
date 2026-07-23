using ECommerce.ViewModels.Category;

namespace ECommerce.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(CategoryCreateOrUpdateVM vm);
        List<CategoryGetVM> GetAll();
        void Remove(int id);
        void Update(int id, CategoryCreateOrUpdateVM vm);
        CategoryGetVM GetById(int id);
    }
}
//CRUD - Create, Read, Update, Delete
