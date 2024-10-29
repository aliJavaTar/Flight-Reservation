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


    public  void CheckDepartureTimeAndArrivalTime()
    {
        if (ArrivalTime <= DepartureTime)
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

    public  void IsValidCity()
    {
        if (ArrivalCity.Equals(DepartureCity))
        {
            throw new ArgumentException("Invalid departure city and arrival city are the same");
        }
    }
}