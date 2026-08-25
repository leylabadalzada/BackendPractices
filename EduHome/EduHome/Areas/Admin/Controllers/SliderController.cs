using EduHome.Services.Interfaces;
using EduHome.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        readonly ISliderService _service;

        public SliderController(ISliderService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(); //yeni sehife acir
        }

        [HttpPost]
        public IActionResult Create(SliderCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Create(vm);
            return RedirectToAction(nameof(Index)); //movcud basqa sehifeye yoneldir
        }
    }
}
