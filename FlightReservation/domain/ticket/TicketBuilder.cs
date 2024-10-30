using FlightReservation.domain.flight;

namespace FlightReservation.domain.ticket;

public class TicketBuilder
{
    private readonly Ticket _ticket = new();

    public TicketBuilder SetPassengerName(string passengerName)
    {
        _ticket.SetPassengerName(passengerName);
        return this;
    }

    public TicketBuilder SetPassengerEmail(string passengerEmail)
    {
        _ticket.SetPassengerEmail(passengerEmail);
        return this;
    }

    public TicketBuilder SetBookingDate(DateTime bookingDate)
    {
        _ticket.SetBookingDate(bookingDate);
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
        _ticket.SetPrice(price);
        return this;
    }

    public Ticket Build()
    {
        return _ticket;
    }
}