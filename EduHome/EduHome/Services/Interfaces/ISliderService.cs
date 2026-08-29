using EduHome.ViewModels.Slider;

namespace EduHome.Services.Interfaces
{
    public interface ISliderService
    {
        void Create(SliderCreateVM vm);
        void Remove(int id);
        void Update(int id, SliderUpdateVM vm);
        List<SliderGetVM> GetAll();
        SliderGetVM GetSingle(int id);
    }
}
