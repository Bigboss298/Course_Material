using Course_Material.Implementation.Service;
using Course_Material.Interface.Service;
using Course_Material.Model.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Course_Material.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LecturerController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly ILecturerService _lecturerService = serviceManager.    LecturerService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] LecturerAccountRequest model)
        {
            try
            {
                var (success, message) = await _lecturerService.Create(model);
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
