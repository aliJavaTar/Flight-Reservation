using FlightReservation.domain;

namespace FlightReservation.infra.repository;

public interface ITicketRepository
{
    Task<Ticket> Add(Ticket ticket);

    Task<Ticket> FindById(int ticketId);
    void Update();
}