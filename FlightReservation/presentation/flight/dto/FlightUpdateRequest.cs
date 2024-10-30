using System.ComponentModel.DataAnnotations;

namespace FlightReservation.presentation.flight.dto;

public class FlightUpdateRequest 
{
    public required int FlightId { get; set; }
    public string? FlightNumber { get; init; }
    public string? DepartureCity { get; init; }
    public string? ArrivalCity { get; init; }
    public DateTime? DepartureTime { get; init; }
    public DateTime? ArrivalTime { get; init; }

    [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100")]
    public int AvailableSeats { get; init; }
}