using FlightReservation.infra.presentation.dto;
using FlightReservation.models;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.infra.presentation;

[ApiController]
[Route("(api/vi/flights)")]
public class FlightController : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FlightRequest request)
    {
        
        return Ok();
    }
}