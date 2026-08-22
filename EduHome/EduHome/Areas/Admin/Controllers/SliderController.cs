using EduHome.Contexts;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private NajibaContext _context;

        public SliderController(NajibaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sliders = _context.sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            var slider = new Slider
            {
                Text = "It is a next sample text",
                Title = "Test Slider 2",
                CreatedAt = DateTime.UtcNow.AddHours(4),
                Image = "slider2.jpg"
            };

            _context.sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
