using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{//todo:HTTP Methods
    public class HomeController : Controller
    {
        private readonly ICategoryService _service;

        public HomeController(ICategoryService service)
        {
            _service = service;
        }

        //action
        public IActionResult Index()
        {
            var vms = _service.GetAll();
            return View(vms);
        } //get


    }
}
