using Microsoft.AspNetCore.Mvc;
using ProjetoSinistroAPI.Services;
using System.Threading.Tasks;

namespace ProjetoSinistroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("External Authentication")]
    public class ExternalAuthController : ControllerBase
    {
        private readonly IExternalAuthService _externalAuthService;

        public ExternalAuthController(IExternalAuthService externalAuthService)
        {
            _externalAuthService = externalAuthService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var isAuthenticated = await _externalAuthService.AuthenticateUserAsync(request.Username, request.Password);

            if (isAuthenticated)
            {
                return Ok("User authenticated successfully.");
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
        }
    }

    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
