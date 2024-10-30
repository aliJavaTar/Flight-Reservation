using FlightReservation.domain.ticket;

namespace FlightReservation.infra.repository.ticket;

public interface ITicketRepository
{
    Task<Ticket> Add(Ticket ticket);

    Task<Ticket> FindById(int ticketId);

    Task<Ticket> FindByPassengerName(string passengerName);
    void Update();
}