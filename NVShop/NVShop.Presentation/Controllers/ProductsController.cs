using Microsoft.AspNetCore.Mvc;
using NVShop.Service.DTOs.Product;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isDeleted)
        {
            var data = await _service.GetAllAsync(isDeleted);
            return StatusCode(200, data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
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

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var message = await _service.RemoveAsync(id);
            return StatusCode(200, message);
        }

        [HttpPatch("toggle/{id}")]
        public async Task<IActionResult> Toggle(int id)
        {
            var message = await _service.ToggleAsync(id);
            return StatusCode(200, message);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            var message = await _service.UpdateAsync(id, dto);
            return StatusCode(200, message);
        }
    }
}
