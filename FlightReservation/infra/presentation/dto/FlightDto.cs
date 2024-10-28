using System.ComponentModel.DataAnnotations;

namespace FlightReservation.infra.presentation.dto;

public class FlightDto 
{
    public required string FlightNumber { get; init; }
    public required string DepartureCity { get; init; }
    public required string ArrivalCity { get; init; }
    public required DateTime DepartureTime { get; init; }
    public required DateTime ArrivalTime { get; init; }

    [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100")]
    public int AvailableSeats { get; init; }
    
}