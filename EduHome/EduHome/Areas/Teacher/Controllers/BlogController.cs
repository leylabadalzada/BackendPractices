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
        readonly ITeacherService _teacherService;
        public BlogController(IBlogService service, ICategoryService categoryService, ITeacherService teacherService)
        {
            _service = service;
            _categoryService = categoryService;
            _teacherService = teacherService;
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
            var teachers = await _teacherService.GetAllAsync();
            ViewBag.Categories = categories
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
            ViewBag.Teachers = teachers
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Firstname} {x.Lastname}"
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
