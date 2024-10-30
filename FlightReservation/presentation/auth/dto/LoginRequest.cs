using System.ComponentModel.DataAnnotations;

namespace FlightReservation.presentation.auth.dto;

public class LoginRequest
{
    [MaxLength(20)] [MinLength(5)] public string? Username { get; set; }

    [MaxLength(100, ErrorMessage = "password must be between 8 and 100 characters")]
    [MinLength(8)]
    public required string Password { get; set; }

    [EmailAddress] public string? Email { get; set; }
}