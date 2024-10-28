using FlightReservation.infra.presentation.dto;
using FlightReservation.infra.presentation.dto.mapper;
using FlightReservation.infra.repository;

namespace FlightReservation.domain.useCase.flight;

public class AddAndModify(IFlightRepository flightRepository, FlightMapper flightMapper)
{
    public async Task<FlightResponse> Add(FlightDto flightDto)
    {
        var flight = flightMapper.ConvertToEntity(flightDto);
        var flightCreated = await flightRepository.CreateAsync(flight);
        return flightMapper.ConvertToResponse(flightCreated);
    }

    public async Task<FlightResponse> Update(FlightDto flightDto, int flightId)
    {
        var flight = flightMapper.ConvertToEntity(flightDto);
        var flightCreated = await flightRepository.CreateAsync(flight);
        return flightMapper.ConvertToResponse(flightCreated);
    }
}