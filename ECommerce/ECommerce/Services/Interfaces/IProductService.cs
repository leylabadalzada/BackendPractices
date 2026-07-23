using ECommerce.ViewModels.Product;

namespace ECommerce.Services.Interfaces
{
    public interface IProductService
    {
        void Create(ProductCreateVM vm);
        List<ProductGetVM> GetAll();
        void Remove(int id);
        void Update(int id, ProductUpdateVM vm);
        ProductGetVM GetById(int id);
    }
}
