using FlightReservation.domain.flight.usecase;
using FlightReservation.infra.models;
using FlightReservation.presentation.flight.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation.flight;

[ApiController]
[Route("api/vi/flights")]
public class FlightController(AddAndModify addAndModify, Search search) : ControllerBase
{
    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FlightDto dto)
    {
        var flightResponse = await addAndModify.Add(dto);
        return CreatedAtAction(nameof(GetFlightById), new { id = flightResponse.FlightId }, flightResponse);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] FlightUpdateRequest request)
    {
        var flightResponse = await addAndModify.Update(request);
        return CreatedAtAction(nameof(GetFlightById), new { id = flightResponse.FlightId }, flightResponse);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveById(int id)
    {
        try
        {
            await addAndModify.Remove(id);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFlightById(int id)
    {
        try
        {
            var flight = await search.GetById(id);
            return Ok(flight);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetAllFlights([FromQuery] FlightSearchDto searchDto)
    {
        var flightResponses = await search.GetFlight(searchDto);
        return CreatedAtAction(nameof(GetFlightById), flightResponses);
    }
}