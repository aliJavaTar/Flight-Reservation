namespace FlightReservation.domain;

public class Ticket
{
    public int Id { get; set; }
    public string PassengerName { get; set; }
    public string PassengerEmail { get; set; }
    public DateTime BookingDate { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public Status Status { get; set; }
    public decimal Price { get; set; }


    public void Buy()
    {
        if (Flight.AvailableSeats == 0)
        {
            throw new Exception("No available seats");
        }

        Flight.AvailableSeats--;
        Status = Status.Resrved;
    }
}