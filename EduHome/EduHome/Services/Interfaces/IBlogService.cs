using EduHome.Areas.Admin.ViewModels.Blog;

namespace EduHome.Services.Interfaces
{
    public interface IBlogService
    {
        Task CreateAsync(BlogCreateVM vm);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, BlogUpdateVM vm);
        Task<List<BlogGetVM>> GetAllAsync();
        Task<BlogGetVM> GetSingleAsync(int id);
    }
}
