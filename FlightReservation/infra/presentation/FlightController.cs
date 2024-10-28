using FlightReservation.models;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.infra.presentation;

[ApiController]
[Route("(api/vi/flights)")]
public class FlightController : ControllerBase
{
    public async Task<IActionResult> Create()
    {
        return Ok();
    }
}