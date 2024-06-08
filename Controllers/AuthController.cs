using DD_FootwearAPI.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using DD_FootwearAPI.Models;

namespace DD_FootwearAPI.Controllers
{
    // AuthController.cs
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(DD_FootwearAPI.Models.LoginRequest model)
        {
            var user = _authService.Authenticate(model.Username, model.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            // You may generate a token here and return it in the response for further authentication

            return Ok(user);
        }
    }

}
