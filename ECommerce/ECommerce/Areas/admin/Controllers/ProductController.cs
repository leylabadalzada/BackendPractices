using ECommerce.Services.Interfaces;
using ECommerce.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var vms = _service.GetAll();
            return View(vms);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = categories
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM vm)
        {
            _service.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var getVM = _service.GetById(id);
            var updateVm = new ProductUpdateVM
            {
                Client = getVM.Client,
                Date = getVM.Date,
                Description = getVM.Description,
                Name = getVM.Name,
                Price = getVM.Price,
                URL = getVM.URL
            };

            return View(updateVm);
        }

        [HttpPost]
        public IActionResult Update(int id, ProductUpdateVM vm)
        {
            _service.Update(id, vm);
            return RedirectToAction(nameof(Index));
        }
    }
}
