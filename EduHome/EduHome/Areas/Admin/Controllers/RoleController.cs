using EduHome.Areas.Admin.ViewModels.Role;
using EduHome.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var vms = await _service.GetAll();
            return View(vms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _service.Create(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
