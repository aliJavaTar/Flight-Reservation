using FlightReservation.infra.repository;
using FlightReservation.infra.repository.flight;
using FlightReservation.presentation.dto.ticket;

namespace FlightReservation.domain.useCase.ticket;

public class AddAndModifyTicket(
    ITicketRepository ticketRepository,
    TicketMapper mapper,
    IFlightRepository flightRepository)
{
    public async Task<Ticket> AddTicket(TicketDto dto)
    {
        var flight = await flightRepository.FindById(dto.FlightId);
        var ticket = mapper.ConvertToEntity(dto);
        ticket.Flight = flight;
        return await ticketRepository.Add(ticket);
    }
}