namespace FlightReservation.models;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; private set; }
    public string DepartureCity { get; private set; }
    public string ArrivalCity { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public DateTime ArrivalTime { get; private set; }
    public int AvailableSeats { get; private set; }
    public List<Ticket> Tickets { get; private set; }

    private Flight()
    {
    }

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
            IsValidData(departureTime);
            _flight.DepartureTime = departureTime;
            return this;
        }

        public FlightBuilder SetArrivalTime(DateTime arrivalTime)
        {
            IsValidData(arrivalTime);
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
            CheckDepartureTimeAndArrivalTime(_flight.DepartureTime, _flight.ArrivalTime);
            IsValidCity(_flight.ArrivalCity, _flight.DepartureCity);
            return _flight;
        }

        private void CheckDepartureTimeAndArrivalTime(DateTime departureTime, DateTime arrivalTime)
        {
            if (Equals(arrivalTime <= departureTime))
            {
                throw new ArgumentException("Invalid arrival time");
            }
        }

        private static void IsValidData(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                throw new ArgumentException("Invalid departure time");
            }
        }

        private static void IsValidCity(string arrivalCity, string departureCity)
        {
            if (arrivalCity.Equals(departureCity))
            {
                throw new ArgumentException("Invalid departure city and arrival city are the same");
            }
        }
    }
}