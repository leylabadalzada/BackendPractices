using Microsoft.AspNetCore.Mvc;
using NVShop.Service.DTOs.Role;
using NVShop.Service.Services.Interfaces;

namespace NVShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly IRoleService _service;

        public RolesController(IRoleService service)
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
        public async Task<IActionResult> Create(RoleCreateDto dto)
        {
            var message = await _service.CreateAsync(dto);
            return StatusCode(200, message);
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
            var message = await _service.RemoveAsync(id);
            return StatusCode(200, message);
        }
    }
}
