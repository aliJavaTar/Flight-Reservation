using FlightReservation.infra.repository;
using FlightReservation.presentation.dto.ticket;

namespace FlightReservation.domain.useCase.ticket;

public class BuyTicket(TicketRepository ticketRepository, TicketMapper mapper)
{
    public async Task<TicketDto> BookingTicket(TicketBookingRequest ticketDto)
    {
        var ticket = await ticketRepository.FindByPassengerName(ticketDto.PassengerName);
        if (ticket.Flight.AvailableSeats == 0)
        {
            throw new Exception("No available seats");
        }

        ticket.Flight.AvailableSeats--;
        ticket.Status = Status.Resrved;

        ticketRepository.Update();

        return mapper.ConvertToDto(ticket);
    }
}