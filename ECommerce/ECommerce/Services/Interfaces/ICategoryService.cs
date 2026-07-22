using ECommerce.ViewModels.Category;

namespace ECommerce.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(CategoryCreateVM vm);
        List<CategoryGetVM> GetAll();
        void Remove(int id);
    }
}
