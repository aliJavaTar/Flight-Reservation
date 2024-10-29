using FlightReservation.infra.presentation.dto;
using FlightReservation.infra.presentation.dto.mapper;
using FlightReservation.infra.repository;
using FlightReservation.presentation.dto.flight;

namespace FlightReservation.domain.useCase.flight;

public class Search(IFlightRepository flightRepository, FlightMapper mapper)
{
    public async Task<FlightResponse> GetById(int id)
    {
        var findFlight = await flightRepository.FindById(id);
        return mapper.ConvertToResponse(findFlight);
    }

    public async Task<List<FlightResponse>> GetFlight()
    {
        return null;
    }
    
}