using FlightReservation.models;

namespace FlightReservation.infra.repository;

public interface IFlightRepository
{
    Task<Flight> CreateAsync(Flight flight);
}