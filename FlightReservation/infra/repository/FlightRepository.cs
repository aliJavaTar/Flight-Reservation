using FlightReservation.domain;
using FlightReservation.infra.data;
using FlightReservation.presentation.dto.flight;
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

    public async Task<Flight> UpdateAsync(Flight flight)
    {
        if (await IsNotCommit())
        {
            throw new ApplicationException("User is not created");
        }

        return flight;
    }

    public Task<List<Flight>> GetAllFlightsFilter(FlightSearchDto flightSearchDto)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> IsNotCommit()
    {
        return await db.SaveChangesAsync() == 0;
    }
}