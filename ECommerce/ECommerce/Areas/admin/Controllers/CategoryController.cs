using ECommerce.Services.Interfaces;
using ECommerce.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var vms = _service.GetAll();
            return View(vms);
        }

        public IActionResult Create()
        {
            return View();
        } //get

        //post - db-e mudaxile etmek demekdir.
        [HttpPost]
        public IActionResult Create(CategoryCreateOrUpdateVM vm)
        {
            _service.Create(vm);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var getVM = _service.GetById(id);
            var updateVM = new CategoryCreateOrUpdateVM
            {
                VmName = getVM.Name
            };
            return View(updateVM);
        }

        [HttpPost]
        public IActionResult Update(int id, CategoryCreateOrUpdateVM vm)
        {
            _service.Update(id, vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
