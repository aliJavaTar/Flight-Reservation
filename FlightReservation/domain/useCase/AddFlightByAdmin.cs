using FlightReservation.infra.presentation.dto;
using FlightReservation.infra.presentation.dto.mapper;
using FlightReservation.infra.repository;
using FlightReservation.models;

namespace FlightReservation.domain.useCase;

public class AddFlightByAdmin(IFlightRepository flightRepository, FlightMapper flightMapper)
{
    public async Task<FlightResponse> add(FlightDto flightDto)
    {
        var flight = flightMapper.ConvertToEntity(flightDto);
        var flightCreated = await flightRepository.CreateAsync(flight);
        return flightMapper.ConvertToResponse(flightCreated);
    }


}