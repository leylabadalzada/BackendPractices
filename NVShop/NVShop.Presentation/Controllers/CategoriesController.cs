using Microsoft.AspNetCore.Mvc;
using NVShop.Service.DTOs.Category;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            var message = await _service.CreateAsync(dto);
            return StatusCode(201, message);
        }
    }
}
