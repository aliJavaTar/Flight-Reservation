using FlightReservation.domain.useCase;
using FlightReservation.domain.useCase.flight;
using FlightReservation.infra.presentation.dto;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.infra.presentation;

[ApiController]
[Route("(api/vi/flights)")]
public class FlightController(AddAndModify addAndModify, Search search) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FlightDto dto)
    {
        var flightResponse = await addAndModify.Add(dto);
        return CreatedAtAction(nameof(GetFlightById), new { id = flightResponse.FlightId }, flightResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] FlightUpdateRequest request)
    {
        var flightResponse = await addAndModify.Update(request);
        return CreatedAtAction(nameof(GetFlightById), new { id = flightResponse.FlightId }, flightResponse);
    }


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
}