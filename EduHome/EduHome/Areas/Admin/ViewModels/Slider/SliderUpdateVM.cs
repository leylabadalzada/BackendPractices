namespace EduHome.Areas.Admin.ViewModels.Slider
{
    public class SliderUpdateVM
    {
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; } //sistemin terkibinde olan fayl formati
        public string? Title { get; set; }
        public string? Text { get; set; }
    }
}
