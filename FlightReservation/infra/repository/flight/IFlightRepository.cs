using FlightReservation.domain;
using FlightReservation.presentation.dto.flight;

namespace FlightReservation.infra.repository;

public interface IFlightRepository
{
    Task<Flight> CreateAsync(Flight flight);
    Task<Flight> FindById(int id);
    Task Remove(int id);
    
    Task<Flight> UpdateAsync(Flight flight);

    Task<List<Flight>> GetAllFlightsFilter(FlightSearchDto flightSearchDto);
}