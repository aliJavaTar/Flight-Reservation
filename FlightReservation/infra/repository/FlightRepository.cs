using FlightReservation.infra.data;
using FlightReservation.models;

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

    private async Task<bool> IsNotCommit()
    {
        return await db.SaveChangesAsync() == 0;
    }
}