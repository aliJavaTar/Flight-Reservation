using FlightReservation.domain;
using FlightReservation.domain.useCase.ticket;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation.dto.ticket;

[ApiController]
[Route("(/tickets)")]
public class TicketController(AddAndModifyTicket addAndModifyTicket) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddTicket([FromBody] TicketDto ticket)
    {
        await addAndModifyTicket.AddTicket(ticket);
        return Ok();
    }
    
}