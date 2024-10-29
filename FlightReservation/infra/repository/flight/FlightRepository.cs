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
            throw new Exception("Flight is not created");
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
        var queryable = db.Flights.AsQueryable();
        if (!string.IsNullOrEmpty(flightSearchDto.FlightNumber))
        {
            queryable = queryable.Where(flight => flight.FlightNumber == flightSearchDto.FlightNumber);
        }

        if (!string.IsNullOrEmpty(flightSearchDto.DepartureCity))
        {
            queryable = queryable.Where(flight => flight.DepartureCity == flightSearchDto.DepartureCity);
        }

        if (!string.IsNullOrEmpty(flightSearchDto.ArrivalCity))
        {
            queryable = queryable.Where(flight => flight.ArrivalCity == flightSearchDto.ArrivalCity);
        }
        if (flightSearchDto.DepartureTime.HasValue)
        {
            queryable = queryable.Where(f => f.DepartureTime.Date == flightSearchDto.DepartureTime.Value.Date);
        }

        if (flightSearchDto.ArrivalTime.HasValue)
        {
            queryable = queryable.Where(f => f.ArrivalTime.Date == flightSearchDto.ArrivalTime.Value.Date);
        }
        queryable = (flightSearchDto.SortBy, flightSearchDto.SortOrder) switch
        {
            (SortBy.FlightNumber, SortOrder.Descending) => queryable.OrderByDescending(f => f.FlightNumber),
            (SortBy.FlightNumber, SortOrder.Ascending) => queryable.OrderBy(f => f.FlightNumber),

            (SortBy.DepartureCity, SortOrder.Descending) => queryable.OrderByDescending(f => f.DepartureCity),
            (SortBy.DepartureCity, SortOrder.Ascending) => queryable.OrderBy(f => f.DepartureCity),

            (SortBy.ArrivalCity, SortOrder.Descending) => queryable.OrderByDescending(f => f.ArrivalCity),
            (SortBy.ArrivalCity, SortOrder.Ascending) => queryable.OrderBy(f => f.ArrivalCity),

            (SortBy.ArrivalTime, SortOrder.Descending) => queryable.OrderByDescending(f => f.ArrivalTime),
            (SortBy.ArrivalTime, SortOrder.Ascending) => queryable.OrderBy(f => f.ArrivalTime),

            (SortBy.DepartureTime, SortOrder.Descending) => queryable.OrderByDescending(f => f.DepartureTime),
            _ => queryable.OrderBy(f => f.Id) 
        };
        
        queryable = queryable.Skip((flightSearchDto.PageNumber - 1) * flightSearchDto.PageSize)
            .Take(flightSearchDto.PageSize);

        
       return queryable.Include(flight => flight.Tickets).ToListAsync();
    }

    private async Task<bool> IsNotCommit()
    {
        return await db.SaveChangesAsync() == 0;
    }
}