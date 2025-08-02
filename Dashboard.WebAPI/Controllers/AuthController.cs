using Dashboard.Application.Commands.Users;
using Dashboard.Application.DTOs.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.WebAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    [AllowAnonymous]
    public sealed class AuthController(IMediator mediatR) : ControllerBase
    {
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var result = await mediatR.Send(new RegisterUserCommand(dto));

            if (!result.IsSuccess)
            {
                return Problem(
                    detail: "Unable to register user.",
                    statusCode: StatusCodes.Status400BadRequest,
                    extensions: new Dictionary<string, object?>
                    {
                { "errors", result.Errors }
                    });
            }

            return Ok(result.Value);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var result = await mediatR.Send(new LoginUserCommand(dto));

            if (!result.IsSuccess)
                return Unauthorized(result.Errors);

            return Ok(result.Value);
        }
    }
}
