using FlightReservation.infra.repository.flight;
using FlightReservation.presentation.flight.dto;
using FlightReservation.presentation.mapper;

namespace FlightReservation.domain.flight.usecase;

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

        flight.IsValidCity();

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

        flight.CheckDepartureTimeAndArrivalTime();

        var updatedFlight = await flightRepository.UpdateAsync(flight);
        return flightMapper.ConvertToResponse(updatedFlight);
    }

    public async Task Remove(int id)
    {
        await flightRepository.Remove(id);
    }
}