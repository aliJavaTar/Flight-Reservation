using System.Security.Claims;
using FlightReservation.infra.repository;
using FlightReservation.infra.repository.ticket;
using FlightReservation.presentation.ticket.dto;

namespace FlightReservation.domain.ticket.useCase;

public class Booking(ITicketRepository ticketRepository, IUserRepository userRepository, TicketMapper mapper)
{
    public async Task<TicketDto> BookingTicket(TicketBookingRequest ticketDto)
    {
        var ticket = await ticketRepository.FindByPassengerName(ticketDto.PassengerName);
        var user = await userRepository.FindUser();
        ticket.UserId = user.Id;
        ticket.User = user;
        ticket.Buy();
        ticketRepository.Update();
        return mapper.ConvertToDto(ticket);
    }
}