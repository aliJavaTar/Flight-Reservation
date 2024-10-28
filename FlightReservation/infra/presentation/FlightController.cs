using FlightReservation.domain.useCase;
using FlightReservation.infra.presentation.dto;
using FlightReservation.models;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.infra.presentation;

[ApiController]
[Route("(api/vi/flights)")]
public class FlightController(AddFlightByAdmin addFlightByAdmin) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FlightDto dto)
    {
        var flightResponse = await addFlightByAdmin.add(dto);
        return Ok();
        // return CreatedAtAction(nameof(GetFlightById), new { id = flightResponse.Id }, flightResponse);

    }
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetFlightById(int id)
    // {
    //     // Retrieve the flight by ID and return it
    //     var flight = await addFlightByAdmin.GetFlightById(id);
    //     if (flight == null) return NotFound();
    //     return Ok(flight);
    // }
}