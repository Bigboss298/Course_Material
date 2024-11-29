using Course_Material.Implementation.Service;
using Course_Material.Interface.Service;
using Course_Material.Model.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Course_Material.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IDepartmentService _departmentService = serviceManager.DepartmentService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(DepartmentRequest model)
        {
            try
            {
                var (success, message) = await _departmentService.Create(model);
                if (success) return Ok(new { success, message });
                return BadRequest(new { success, message });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _departmentService.GetAll();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
