using FlightReservation.infra.data;
using FlightReservation.models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.repository;

public class FlightRepository(Db db) : IFlightRepository
{
    public async Task<Flight> CreateAsync(Flight flight)
    {
        await db.Flights.AddAsync(flight);
        if (await IsNotCommit())
        {
            throw new ApplicationException("User is not created");
        }

        return flight;
    }

    public async Task<Flight> FindById(int id)
    {
        return await db.Flights.FindAsync(id) ?? throw new Exception("Flight is not found");
    }

    private async Task<bool> IsNotCommit()
    {
        return await db.SaveChangesAsync() == 0;
    }
}