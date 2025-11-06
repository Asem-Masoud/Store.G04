using Microsoft.AspNetCore.Mvc;
using Store.G04.Services.Abstractions;
using Store.G04.Shared.Dtos.Auth;
using System.Threading.Tasks;

namespace Store.G04.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IServiceManger _serviceManger) : ControllerBase
    {
        // login
        [HttpPost("login")] // POST: baseUrl/api/auth/login
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _serviceManger.AuthService.LoginAsync(request);
            return Ok(result);
        }

        // register
        [HttpPost("register")] // POST: baseUrl/api/auth/register
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _serviceManger.AuthService.RegisterAsync(request);
            return Ok(result);
        }

    }
}
