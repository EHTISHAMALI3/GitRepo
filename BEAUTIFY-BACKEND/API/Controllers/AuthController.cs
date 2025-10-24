using BEAUTIFY.APPLICATION.DTO;
using BEAUTIFY.APPLICATION.INTERFACE;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEAUTIFY.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepository.RegisterAsync(model);

            if (!result.Success)
                return BadRequest(new { errors = result.Errors });

            return Ok(new { token = result.Token, refreshToken = result.RefreshToken });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepository.LoginAsync(model);

            if (!result.Success)
                return Unauthorized(new { errors = result.Errors });

            return Ok(new { token = result.Token, refreshToken = result.RefreshToken });
        }

        [HttpGet("lockout-status/{userId}")]
        public async Task<IActionResult> IsLockedOut(string userId)
        {
            var isLockedOut = await _authRepository.IsLockedOutAsync(userId);
            return Ok(new { isLockedOut });
        }

        [HttpPost("validate-captcha")]
        public async Task<IActionResult> ValidateCaptcha([FromBody] string captchaResponse)
        {
            var isValid = await _authRepository.ValidateCaptchaAsync(captchaResponse);
            return Ok(new { isValid });
        }
    }
}

