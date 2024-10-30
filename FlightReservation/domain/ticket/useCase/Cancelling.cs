using FlightReservation.infra.repository;

namespace FlightReservation.domain.ticket.useCase;

public class Cancelling(ITicketRepository ticketRepository)
{
    public async Task CancelTicket(int id)
    {
        var ticket = await ticketRepository.FindById(id);
        if (ticket.Status.Equals(Status.Resrved))
        {
            ticket.Status = Status.Canceel;
            ticket.Flight.AvailableSeats++;
        }

        ticketRepository.Update();
    }
}