using FlightReservation.domain.flight;
using FlightReservation.presentation.flight.dto;

namespace FlightReservation.presentation.mapper;

public class FlightMapper
{
    public Flight ConvertToEntity(FlightDto flightDto)
    {
        return new FlightBuilder()
            .SetFlightNumber(flightDto.FlightNumber)
            .SetAvailableSeats(flightDto.AvailableSeats)
            .SetArrivalCity(flightDto.ArrivalCity)
            .SetDepartureCity(flightDto.DepartureCity)
            .SetArrivalTime(flightDto.ArrivalTime)
            .SetDepartureTime(flightDto.DepartureTime)
            .Build();
    }
    
   
    
    public FlightResponse ConvertToResponse(Flight flight)
    {
        return new FlightResponse
        {
            FlightId = flight.Id,
            DepartureCity = flight.DepartureCity,
            FlightNumber = flight.FlightNumber,
            ArrivalCity = flight.ArrivalCity,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            AvailableSeats = flight.AvailableSeats,
        };
    }
}