using FlightReservation.infra.repository;
using FlightReservation.infra.repository.ticket;

namespace FlightReservation.domain.ticket.useCase;

public class Cancelling(ITicketRepository ticketRepository, IUserRepository userRepository)
{
    public async Task CancelTicket(int id)
    {
        var ticket = await ticketRepository.FindById(id);
        if (ticket.Flight is null)
            throw new Exception("Flight is null ");

        var user = await userRepository.FindUser();

        if (user.TicketId != ticket.Id)
            throw new Exception("you can not cancel the ticket");


        if (ticket.Status.Equals(Status.Resrved))
        {
            ticket.Status = Status.Canceel;
            ticket.Flight.AvailableSeats++;
        }


        ticketRepository.Update();
    }
}