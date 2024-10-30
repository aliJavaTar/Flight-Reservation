using System.ComponentModel.DataAnnotations;

namespace FlightReservation.infra.models;

public class User
{
    public int Id { get; set; }
    [MaxLength(20)] [MinLength(5)] public required string Username { get; set; }
    [EmailAddress] public required string Email { get; set; }

    [MaxLength(100, ErrorMessage = "password must be between 8 and 100 characters")]
    [MinLength(8)]
    public required string PasswordHash { get; set; }

    public required Role Role { get; set; }
}