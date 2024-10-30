using FlightReservation.infra.auth;
using FlightReservation.presentation.auth.dto;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation.auth;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            var result = await authService.Register(request);
            return Ok(result);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest("invalid request");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await authService.Login(request);
        return Ok(new { Token = token });
    }
}