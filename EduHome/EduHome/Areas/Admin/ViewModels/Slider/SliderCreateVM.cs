using System.ComponentModel.DataAnnotations;

namespace EduHome.Areas.Admin.ViewModels.Slider
{
    public record SliderCreateVM
    {
        public IFormFile Image { get; set; } //sistemin terkibinde olan fayl formati
        [Required]
        [MinLength(3)] //Data Annotation Validation
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Text { get; set; }
    }
}
