using FlightReservation.infra.models;

namespace FlightReservation.presentation.auth.dto;

public class AuthResponse
{
    public string? Token { get; set; }
    public Role Role { get; set; }
}