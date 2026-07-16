using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        //action
        public IActionResult Index()
        {
            return View();
        }
    }
}
