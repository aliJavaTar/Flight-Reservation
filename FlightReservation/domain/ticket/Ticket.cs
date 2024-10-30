using System.ComponentModel.DataAnnotations;
using FlightReservation.domain.flight;
using FlightReservation.infra.models;

namespace FlightReservation.domain.ticket;

public class Ticket
{
    public int Id { get; set; }
    [MaxLength(100)] public string? PassengerName { get; private set; }
    [MaxLength(100)] public string? PassengerEmail { get; private set; }
    public DateTime BookingDate { get; private set; }
    public int FlightId { get; set; }
    public Flight? Flight { get; set; }
    public Status Status { get; set; }
    public decimal Price { get; private set; }

    public int UserId { get; set; }
    public User? User { get; set; }


    public void SetPassengerName(string passengerName)
    {
        if (passengerName.Trim().Length < 3)
        {
            throw new ArgumentException("Passenger name must be at least 3 characters");
        }

        PassengerName = passengerName;
    }

    public void SetPassengerEmail(string passengerEmail)
    {
        if (passengerEmail.Trim().Length < 3 || !passengerEmail.Contains("@"))
        {
            throw new ArgumentException("Passenger name must be at least 3 characters");
        }

        PassengerEmail = passengerEmail;
    }

    public void SetBookingDate(DateTime bookingDate)
    {
        if (bookingDate <= DateTime.Now)
        {
            throw new ArgumentException("Booking date must be in the future");
        }

        BookingDate = bookingDate;
    }


    public void Buy()
    {
        if (Flight is null || Flight.AvailableSeats == 0)
        {
            throw new Exception("No available seats");
        }

        Flight.AvailableSeats--;
        Status = Status.Resrved;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }

        Price = price;
    }
}