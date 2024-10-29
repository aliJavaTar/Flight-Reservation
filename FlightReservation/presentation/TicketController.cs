using FlightReservation.domain.useCase.ticket;
using FlightReservation.presentation.dto.ticket;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation;

[ApiController]
[Route("(/tickets)")]
public class TicketController(AddAndModifyTicket addAndModifyTicket, Booking booking , Cancelling cancelling) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddTicket([FromBody] TicketDto ticket)
    {
        await addAndModifyTicket.AddTicket(ticket);
        return Ok();
    }

    [HttpPut("/booking")]
    public async Task<IActionResult> AddTicket([FromBody] TicketBookingRequest request)
    {
        await booking.BookingTicket(request);
        return Ok();
    }

    [HttpGet("/cancel")]
    public async Task<IActionResult> AddTicket([FromQuery] int id)
    {
        await cancelling.CancelTicket(id);
        return Ok();
    }
}