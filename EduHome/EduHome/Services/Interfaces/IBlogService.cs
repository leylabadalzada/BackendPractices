using EduHome.Areas.Admin.ViewModels.Blog;

namespace EduHome.Services.Interfaces
{
    public interface IBlogService
    {
        void Create(BlogCreateVM vm);
        void Remove(int id);
        void Update(int id, BlogUpdateVM vm);
        List<BlogGetVM> GetAll();
        BlogGetVM GetSingle(int id);
    }
}
