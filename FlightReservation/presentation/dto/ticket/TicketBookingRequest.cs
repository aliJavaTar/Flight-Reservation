namespace FlightReservation.presentation.dto.ticket;

public class TicketBookingRequest(int flightId, string passengerName, string passengerEmail)
{
    public required int FlightId = flightId;
    public required string PassengerName = passengerName;
    public required string PassengerEmail = passengerEmail;
}