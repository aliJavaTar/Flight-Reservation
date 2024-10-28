using System.ComponentModel.DataAnnotations;

namespace FlightReservation.infra.presentation.dto;

public class FlightDto
{
    public required string FlightNumber { get; init; }
    public required string DepartureCity { get; init; }
    public required string ArrivalCity { get; init; }
    public required DateTime DepartureTime { get; set; }
    public required DateTime ArrivalTime { get; set; }

    [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100")]
    public int AvailableSeats { get; init; }


    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    public required decimal Price { get; init; }
}