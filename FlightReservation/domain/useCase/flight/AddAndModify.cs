using FlightReservation.infra.presentation.dto;
using FlightReservation.infra.presentation.dto.mapper;
using FlightReservation.infra.repository;
using FlightReservation.presentation.dto.flight;

namespace FlightReservation.domain.useCase.flight;

public class AddAndModify(IFlightRepository flightRepository, FlightMapper flightMapper)
{
    public async Task<FlightResponse> Add(FlightDto flightDto)
    {
        var flight = flightMapper.ConvertToEntity(flightDto);
        var flightCreated = await flightRepository.CreateAsync(flight);
        return flightMapper.ConvertToResponse(flightCreated);
    }

    public async Task<FlightResponse> Update(FlightUpdateRequest flightDto)
    {
        var flight = await flightRepository.FindById(flightDto.FlightId);

        if (flightDto.ArrivalCity != null)
        {
            flight.ArrivalCity = flightDto.ArrivalCity;
        }

        if (flightDto.DepartureCity != null)
        {
            flight.DepartureCity = flightDto.DepartureCity;
        }

        Flight.IsValidCity(flight.ArrivalCity, flight.DepartureCity);

        if (flightDto.FlightNumber != null)
        {
            flight.FlightNumber = flightDto.FlightNumber;
        }

        if (flightDto.AvailableSeats != flight.AvailableSeats)
        {
            flight.AvailableSeats = flight.AvailableSeats;
        }

        if (flightDto.ArrivalTime != null)
        {
            flight.ArrivalTime = (DateTime)flightDto.ArrivalTime;
        }

        if (flightDto.DepartureTime != null)
        {
            flight.ArrivalTime = (DateTime)flightDto.DepartureTime;
        }

        Flight.CheckDepartureTimeAndArrivalTime(flight.ArrivalTime, flight.DepartureTime);

        var updatedFlight = await flightRepository.UpdateAsync(flight);
        return flightMapper.ConvertToResponse(updatedFlight);
    }
}