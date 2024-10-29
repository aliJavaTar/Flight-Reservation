namespace FlightReservation.domain;

public class FlightBuilder
{
    private readonly Flight _flight = new();


    public FlightBuilder SetFlightNumber(string flightNumber)
    {
        if (flightNumber is null || flightNumber.Trim().Length < 2)
        {
            throw new ArgumentException("Invalid flight number");
        }

        _flight.FlightNumber = flightNumber;

        return this;
    }

    public FlightBuilder SetDepartureCity(string departureCity)
    {
        if (departureCity is null || departureCity.Trim().Length < 2)
        {
            throw new ArgumentException("Invalid flight number");
        }

        _flight.DepartureCity = departureCity;
        return this;
    }

    public FlightBuilder SetArrivalCity(string arrivalCity)
    {
        if (arrivalCity is null || arrivalCity.Trim().Length < 2)
        {
            throw new ArgumentException("Invalid flight number");
        }

        _flight.ArrivalCity = arrivalCity;
        return this;
    }

    public FlightBuilder SetDepartureTime(DateTime departureTime)
    {
        _flight.IsValidData(departureTime);
        _flight.DepartureTime = departureTime;
        return this;
    }

    public FlightBuilder SetArrivalTime(DateTime arrivalTime)
    {
        _flight.IsValidData(arrivalTime);
        _flight.ArrivalTime = arrivalTime;
        return this;
    }


    public FlightBuilder SetAvailableSeats(int availableSeats)
    {
        if (availableSeats < 0)
            throw new ArgumentException("Invalid available seats");
        _flight.AvailableSeats = availableSeats;
        return this;
    }


    public FlightBuilder SetTickets(List<Ticket> tickets)
    {
        _flight.Tickets = tickets;
        return this;
    }

    public Flight Build()
    {
        _flight.CheckDepartureTimeAndArrivalTime();
        _flight.IsValidCity();
        return _flight;
    }
}