using EduHome.Areas.Admin.ViewModels.Slider;

namespace EduHome.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateVM vm);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, SliderUpdateVM vm);
        Task<List<SliderGetVM>> GetAllAsync();
        Task<SliderGetVM> GetSingleAsync(int id);
    }
}
