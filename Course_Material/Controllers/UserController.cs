using Course_Material.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Course_Material.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IUserService _userService = serviceManager.UserService;

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                var response = await _userService.Login(userName, password);
                if (response.Success) return Ok(response);
                return Unauthorized(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
