using FlightReservation.domain.ticket.useCase;
using FlightReservation.infra.models;
using FlightReservation.Middlewares;
using FlightReservation.presentation.ticket.dto;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.presentation.ticket;

[ApiController]
[Route("tickets")]
public class TicketController(AddAndModifyTicket addAndModifyTicket, Booking booking, Cancelling cancelling)
    : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddTicket([FromBody] TicketDto ticket)
    {
        await addAndModifyTicket.AddTicket(ticket);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = nameof(Role.Customer))]
    public async Task<IActionResult> Booking([FromBody] TicketBookingRequest request)
    {
        await booking.BookingTicket(request);
        return Ok();
    }

    [Authorize(Roles = nameof(Role.Customer))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Cancel(int id)
    {
        await cancelling.CancelTicket(id);
        return Ok();
    }
}