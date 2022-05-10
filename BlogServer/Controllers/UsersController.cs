using BlogBLL.ModelRequest;
using BlogBLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlogServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        ILogger _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest loginRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var token = await _userService.Authenticate(loginRequest);
                if (token == null)
                {
                    return BadRequest("User or Password is incorrect");
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Authenticate action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest registerRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var result = await _userService.Register(registerRequest);
                if (!result)
                {
                    return BadRequest("Register is unsuccessful");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
