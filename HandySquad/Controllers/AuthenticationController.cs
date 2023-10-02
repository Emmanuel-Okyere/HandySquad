using HandySquad.dto;
using HandySquad.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HandySquad.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
    {
        return Created("",await _authenticationService.Register(registerRequestDto));
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        return Ok(await _authenticationService.Login(loginRequestDto));
    }
}