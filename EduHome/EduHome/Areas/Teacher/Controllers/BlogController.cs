using EduHome.Areas.Admin.ViewModels.Blog;
using EduHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHome.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class BlogController : Controller
    {
        readonly IBlogService _service;
        readonly ICategoryService _categoryService;

        public BlogController(IBlogService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var vms = await _service.GetAllAsync();
            return View(vms);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _service.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var getVM = await _service.GetSingleAsync(id);
            var vm = new BlogUpdateVM
            {
                ImageName = getVM.Image,
                Text = getVM.Text,
                Title = getVM.Title
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, BlogUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _service.UpdateAsync(id, vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
