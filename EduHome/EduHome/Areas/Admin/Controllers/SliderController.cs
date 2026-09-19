using EduHome.Areas.Admin.ViewModels.Slider;
using EduHome.Services.Interfaces;
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

        public async Task<IActionResult> Index()
        {
            var vms = await _service.GetAllAsync();
            return View(vms);
        }

        public IActionResult Create()
        {
            return View(); //yeni sehife acir
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index)); //movcud basqa sehifeye yoneldir
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction(nameof(Index)); //movcud basqa sehifeye yoneldir
        }

        public async Task<IActionResult> Update(int id)
        {
            var slider = await _service.GetSingleAsync(id);
            var vm = new SliderUpdateVM
            {
                ImageName = slider.Image,
                Text = slider.Text,
                Title = slider.Title
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, SliderUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _service.UpdateAsync(id, vm);
            return RedirectToAction(nameof(Index)); //movcud basqa sehifeye yoneldir
        }
    }
}
