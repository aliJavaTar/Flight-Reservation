namespace FlightReservation.domain;

public class TicketBuilder
{
    private readonly Ticket _ticket = new();

    public TicketBuilder SetPassengerName(string passengerName)
    {
        if (passengerName.Trim().Length < 3)
        {
            throw new ArgumentException("Passenger name must be at least 3 characters");
        }

        _ticket.PassengerName = passengerName;
        return this;
    }

    public TicketBuilder SetPassengerEmail(string passengerEmail)
    {
        if (passengerEmail.Trim().Length < 3 || !passengerEmail.Contains("@"))
        {
            throw new ArgumentException("Passenger name must be at least 3 characters");
        }

        _ticket.PassengerEmail = passengerEmail;
        return this;
    }

    public TicketBuilder SetBookingDate(DateTime bookingDate)
    {
        if (bookingDate <= DateTime.Now)
        {
            throw new ArgumentException("Booking date must be in the future");
        }

        _ticket.BookingDate = bookingDate;
        return this;
    }

    public TicketBuilder SetFlight(Flight flight)
    {
        _ticket.Flight = flight;
        return this;
    }

    public TicketBuilder SetFlightId(int flightId)
    {
        _ticket.FlightId = flightId;
        return this;
    }

    public TicketBuilder SetStatus(Status status)
    {
        _ticket.Status = status;
        return this;
    }

    public TicketBuilder SetPrice(decimal price)
    {
        _ticket.Price = price;
        return this;
    }

    public Ticket Build()
    {
        return _ticket;
    }
}