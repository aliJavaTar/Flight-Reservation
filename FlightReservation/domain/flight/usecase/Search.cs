using FlightReservation.infra.repository.flight;
using FlightReservation.presentation.dto.flight;
using FlightReservation.presentation.dto.flight.mapper;

namespace FlightReservation.domain.flight.usecase;

public class Search(IFlightRepository flightRepository, FlightMapper mapper)
{
    public async Task<FlightResponse> GetById(int id)
    {
        var findFlight = await flightRepository.FindById(id);
        return mapper.ConvertToResponse(findFlight);
    }

    public async Task<List<FlightResponse>> GetFlight(FlightSearchDto request)

    {
        var flights = await flightRepository.GetAllFlightsFilter(request);
        return FlightResponses(flights);
    }

    private List<FlightResponse> FlightResponses(List<Flight> flights)
    {
        List<FlightResponse> flightResponses = new List<FlightResponse>();
        foreach (var flight in flights)
        {
            flightResponses.Add(mapper.ConvertToResponse(flight));
        }

        return flightResponses;
    }
}