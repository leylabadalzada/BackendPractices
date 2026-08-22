using EduHome.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private NajibaContext _context;

        public HomeController(NajibaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sliders = _context.sliders.ToList();
            return View(sliders);
        }
    }
}
