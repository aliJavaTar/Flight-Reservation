using FlightReservation.domain;
using FlightReservation.domain.flight;
using FlightReservation.presentation.flight.dto;

namespace FlightReservation.infra.repository.flight;

public interface IFlightRepository
{
    Task<Flight> CreateAsync(Flight flight);
    Task<Flight> FindById(int id);
    Task Remove(int id);
    
    Task<Flight> UpdateAsync(Flight flight);

    Task<List<Flight>> GetAllFlightsFilter(FlightSearchDto flightSearchDto);
}