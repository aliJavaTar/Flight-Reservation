using FlightReservation.domain;
using FlightReservation.infra.data;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.repository;

public class TicketRepository(Db db) : ITicketRepository
{
    public async Task<Ticket> Add(Ticket ticket)
    {
        await db.Tickets.AddAsync(ticket);
        if (await IsNotCommit())
        {
            throw new Exception("Ticket is not created");
        }

        return ticket;
    }

    public async Task<Ticket> FindById(int ticketId)
    {
        return await db.Tickets.FindAsync(ticketId) ?? throw new NullReferenceException("Ticket not found");
    }


    public async Task<Ticket> FindByPassengerName(string passengerName)
    {
        var ticketFound = await db.Tickets.FirstOrDefaultAsync(ticket => ticket.PassengerName == passengerName);
        return ticketFound ?? throw new Exception("Ticket not found");
    }

    private async Task<bool> IsNotCommit()
    {
        return await db.SaveChangesAsync() == 0;
    }

    public async void Update()
    {
        if (await IsNotCommit())
        {
            throw new Exception("Ticket is not created");
        }
    }
}