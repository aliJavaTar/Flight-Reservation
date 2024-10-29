namespace FlightReservation.domain;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AvailableSeats { get; set; }
    public List<Ticket> Tickets { get; set; }

 
    // public class FlightBuilder
    // {
    //     private readonly Flight _flight = new();
    //
    //
    //     public FlightBuilder SetFlightNumber(string flightNumber)
    //     {
    //         if (flightNumber is null || flightNumber.Trim().Length < 2)
    //         {
    //             throw new ArgumentException("Invalid flight number");
    //         }
    //
    //         _flight.FlightNumber = flightNumber;
    //
    //         return this;
    //     }
    //
    //     public FlightBuilder SetDepartureCity(string departureCity)
    //     {
    //         if (departureCity is null || departureCity.Trim().Length < 2)
    //         {
    //             throw new ArgumentException("Invalid flight number");
    //         }
    //
    //         _flight.DepartureCity = departureCity;
    //         return this;
    //     }
    //
    //     public FlightBuilder SetArrivalCity(string arrivalCity)
    //     {
    //         if (arrivalCity is null || arrivalCity.Trim().Length < 2)
    //         {
    //             throw new ArgumentException("Invalid flight number");
    //         }
    //
    //         _flight.ArrivalCity = arrivalCity;
    //         return this;
    //     }
    //
    //     public FlightBuilder SetDepartureTime(DateTime departureTime)
    //     {
    //         IsValidData(departureTime);
    //         _flight.DepartureTime = departureTime;
    //         return this;
    //     }
    //
    //     public FlightBuilder SetArrivalTime(DateTime arrivalTime)
    //     {
    //         IsValidData(arrivalTime);
    //         _flight.ArrivalTime = arrivalTime;
    //         return this;
    //     }
    //
    //
    //     public FlightBuilder SetAvailableSeats(int availableSeats)
    //     {
    //         if (availableSeats < 0)
    //             throw new ArgumentException("Invalid available seats");
    //         _flight.AvailableSeats = availableSeats;
    //         return this;
    //     }
    //
    //
    //     public FlightBuilder SetTickets(List<Ticket> tickets)
    //     {
    //         _flight.Tickets = tickets;
    //         return this;
    //     }
    //
    //     public Flight Build()
    //     {
    //         CheckDepartureTimeAndArrivalTime(_flight.DepartureTime, _flight.ArrivalTime);
    //         IsValidCity(_flight.ArrivalCity, _flight.DepartureCity);
    //         return _flight;
    //     }
    // }

    public  void CheckDepartureTimeAndArrivalTime(DateTime departureTime, DateTime arrivalTime)
    {
        if (arrivalTime <= departureTime)
        {
            throw new ArgumentException("Invalid arrival time");
        }
    }

    public  void IsValidData(DateTime dateTime)
    {
        if (dateTime < DateTime.Now)
        {
            throw new ArgumentException("Invalid departure time");
        }
    }

    public  void IsValidCity(string arrivalCity, string departureCity)
    {
        if (arrivalCity.Equals(departureCity))
        {
            throw new ArgumentException("Invalid departure city and arrival city are the same");
        }
    }
}