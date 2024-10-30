using FlightReservation.infra.repository;
using FlightReservation.infra.repository.flight;
using FlightReservation.infra.repository.ticket;
using FlightReservation.presentation.ticket.dto;

namespace FlightReservation.domain.ticket.useCase;

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