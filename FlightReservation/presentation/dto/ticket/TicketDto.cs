using System.ComponentModel.DataAnnotations;

namespace FlightReservation.presentation.dto.ticket;

public class TicketDto
{
    public required string PassengerName { get; set; }
    public required string PassengerEmail { get; set; }
    public required DateTime BookingDate { get; set; }
    public required int FlightId { get; set; }

    [Range(0, Double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
}