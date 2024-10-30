using FlightReservation.domain.ticket;
using FlightReservation.infra.data;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.repository.ticket;

public class TicketRepository(DataBase dataBase) : ITicketRepository
{
    public async Task<Ticket> Add(Ticket ticket)
    {
        await dataBase.Tickets.AddAsync(ticket);
        if (await IsNotCommit())
        {
            throw new Exception("Ticket is not created");
        }

        return ticket;
    }

    public async Task<Ticket> FindById(int ticketId)
    {
        return await dataBase.Tickets.FindAsync(ticketId) ?? throw new NullReferenceException("Ticket not found");
    }


    public async Task<Ticket> FindByPassengerName(string passengerName)
    {
        var ticketFound = await dataBase.Tickets.FirstOrDefaultAsync(ticket => ticket.PassengerName == passengerName);
        return ticketFound ?? throw new Exception("Ticket not found");
    }

    private async Task<bool> IsNotCommit()
    {
        return await dataBase.SaveChangesAsync() == 0;
    }

    public async void Update()
    {
        if (await IsNotCommit())
        {
            throw new Exception("Ticket is not created");
        }
    }
}