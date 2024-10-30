using FlightReservation.domain.ticket.useCase;
using FlightReservation.presentation.ticket.dto;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation.ticket;

[ApiController]
[Route("tickets")]
public class TicketController(AddAndModifyTicket addAndModifyTicket, Booking booking, Cancelling cancelling)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddTicket([FromBody] TicketDto ticket)
    {
        await addAndModifyTicket.AddTicket(ticket);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Booking([FromBody] TicketBookingRequest request)
    {
        await booking.BookingTicket(request);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Cancel(int id)
    {
        await cancelling.CancelTicket(id);
        return Ok();
    }
}