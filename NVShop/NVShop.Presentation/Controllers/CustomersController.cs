using Microsoft.AspNetCore.Mvc;
using NVShop.Service.DTOs.Customer;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return StatusCode(200, data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterDto dto)
        {
            var message = await _service.RegisterAsync(dto);
            return StatusCode(201, message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var data = await _service.GetSingleAsync(id);
            return StatusCode(200, data);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            var message = await _service.RemoveAccountAsync(id);
            return StatusCode(200, message);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(string id, CustomerUpdateDto dto)
        {
            var message = await _service.UpdateAsync(id, dto);
            return StatusCode(200, message);
        }
    }
}
