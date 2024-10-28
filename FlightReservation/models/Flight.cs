namespace FlightReservation.models;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int AvailableSeats { get; set; }
    public decimal Price { get; set; }
    public List<Ticket> Tickets { get; set; }

}