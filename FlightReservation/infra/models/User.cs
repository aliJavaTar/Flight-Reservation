using System.ComponentModel.DataAnnotations;
using FlightReservation.domain.ticket;

namespace FlightReservation.infra.models;

public class User(string? email, string? username, Role role)
{
    public int Id { get; set; }

    [MaxLength(20)] [MinLength(5)] public string? Username { get; set; }

    [EmailAddress]
    [MaxLength(100, ErrorMessage = "email is no more than 100 characters")]
    public string? Email { get; set; }

    [MaxLength(100, ErrorMessage = "password must be between 8 and 100 characters")]
    [MinLength(8)]
    public string? PasswordHash { get; set; }

    public Role Role { get; set; }

    public int TicketId { get; set; }

    public Ticket? Ticket { get; set; }
}