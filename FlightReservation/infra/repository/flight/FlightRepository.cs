using FlightReservation.domain;
using FlightReservation.domain.flight;
using FlightReservation.infra.data;
using FlightReservation.presentation.flight;
using FlightReservation.presentation.flight.dto;
using Microsoft.EntityFrameworkCore;

namespace FlightReservation.infra.repository.flight;

public class FlightRepository(DataBase dataBase) : IFlightRepository
{
    public async Task<Flight> CreateAsync(Flight flight)
    {
        await dataBase.Flights.AddAsync(flight);
        if (await IsNotCommit())
        {
            throw new Exception("Flight is not created");
        }

        return flight;
    }

    public async Task<Flight> FindById(int id)
    {
        return await dataBase.Flights.FindAsync(id) ?? throw new Exception("Flight is not found");
    }

    public async Task Remove(int id)
    {
        var flight = await FindById(id);
        dataBase.Flights.Remove(flight);
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
        var queryable = dataBase.Flights.AsQueryable();
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
        return await dataBase.SaveChangesAsync() == 0;
    }
}