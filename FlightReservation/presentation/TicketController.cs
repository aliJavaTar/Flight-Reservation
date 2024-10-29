using FlightReservation.domain.useCase.ticket;
using FlightReservation.presentation.dto.ticket;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation;

[ApiController]
[Route("(/tickets)")]
public class TicketController(AddAndModifyTicket addAndModifyTicket, BuyTicket buyTicket) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddTicket([FromBody] TicketDto ticket)
    {
        await addAndModifyTicket.AddTicket(ticket);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> AddTicket([FromBody] TicketBookingRequest request)
    {
        await buyTicket.BookingTicket(request);
        return Ok();
    }
}