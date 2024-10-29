using FlightReservation.infra.repository;
using FlightReservation.presentation.dto.ticket;

namespace FlightReservation.domain.useCase.ticket;

public class Booking(ITicketRepository ticketRepository, TicketMapper mapper)
{
    
    public async Task<TicketDto> BookingTicket(TicketBookingRequest ticketDto)
    {
        var ticket = await ticketRepository.FindByPassengerName(ticketDto.PassengerName);
        ticket.Booking();
        ticketRepository.Update();
        return mapper.ConvertToDto(ticket);
    }
}