using BlogBLL;
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
        #region Properties
        IUserService _userService;
        ILogger _logger;
        #endregion

        #region Constructor
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService  ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Method

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest loginRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new Response<LoginRequest>("InValid values"));

                var token = await _userService.Authenticate(loginRequest);
                if (token == null)
                {
                    return BadRequest(new Response<LoginRequest>("User or Password is incorrect"));
                }
                return Ok(new Response<string>(token,""));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Authenticate action: {ex.Message}");
                return StatusCode(500, new Response<LoginRequest>("Internal server error"));
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest registerRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new Response<LoginRequest>("InValid values"));

                var result = await _userService.Register(registerRequest);
                if (!result)
                {
                    return BadRequest(new Response<LoginRequest>("Register is unsuccessful"));
                }
                return Ok(new Response<LoginRequest>());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
                return StatusCode(500, new Response<LoginRequest>("Internal server error"));
            }
        }
        #endregion
    }
}
