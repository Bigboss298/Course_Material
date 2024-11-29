using Course_Material.Interface.Service;
using Course_Material.Model.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Course_Material.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IStudentService _studentService = serviceManager.StudentService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] StudentAccountRequest student)
        {
            try
            {
                var (success, message) = await _studentService.Create(student);
                if (success) return Ok(new { success, message });
                return BadRequest(new { success, message });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
