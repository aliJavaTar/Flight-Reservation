using FlightReservation.domain;

namespace FlightReservation.infra.repository;

public interface IFlightRepository
{
    Task<Flight> CreateAsync(Flight flight);
    Task<Flight> FindById(int id);


    Task<Flight> UpdateAsync(Flight flight);
}