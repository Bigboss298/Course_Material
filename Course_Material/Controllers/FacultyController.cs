using Course_Material.Implementation.Service;
using Course_Material.Interface.Service;
using Course_Material.Model.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Course_Material.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FacultyController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IFacultyService _facultyService = serviceManager.FacultyService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(string name)
        {
            try
            {
                var (success, message) = await _facultyService.Create(name);
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
                var faculties = await _facultyService.GetAll();
                return Ok(faculties);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
