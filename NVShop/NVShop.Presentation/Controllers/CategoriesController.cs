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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isDeleted)
        {
            var data = await _service.GetAllAsync(isDeleted);
            return StatusCode(200, data);
        }

        [HttpPost] //_context.Add, login/logout
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            var message = await _service.CreateAsync(dto);
            return StatusCode(201, message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id, bool? isDeleted)
        {
            var data = await _service.GetSingleAsync(id, isDeleted);
            return StatusCode(200, data);
        }


        [HttpDelete] //_context_Remove
        public async Task<IActionResult> Remove(int id)
        {
            var message = await _service.RemoveAsync(id);
            return StatusCode(200, message);
        }

        [HttpPatch("toggle")] //_context_Update
        public async Task<IActionResult> Toggle(int id)
        {
            var message = await _service.ToggleAsync(id);
            return StatusCode(200, message);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
        {
            var message = await _service.UpdateAsync(id, dto);
            return StatusCode(200, message);
        }
    }
}
