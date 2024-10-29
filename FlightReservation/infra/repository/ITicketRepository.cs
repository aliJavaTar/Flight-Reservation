using FlightReservation.domain;

namespace FlightReservation.infra.repository;

public interface ITicketRepository
{
    Task<Ticket> Add(Ticket ticket);
}