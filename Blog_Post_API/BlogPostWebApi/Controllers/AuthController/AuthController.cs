using BlogPost.Application.Dto.Request;
using BlogPost.Application.Interfaces.Auth;
using BlogPost.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostWebApi.Controllers.AuthController
{
    [Route("api/user-management")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #region Login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> login([FromBody] LoginRequest loginRequest)
        {
            var res = await _authService.Login(loginRequest);
            return Ok(res);
        }
        #endregion Login

        #region Save
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var result = await _authService.Register(request);
            return Ok(result);
        }
        #endregion Save
    }
}
