using FlightReservation.infra.models;

namespace FlightReservation.presentation.auth.dto;

public class RegisterRequest : LoginRequest
{
 
    public required Role Role { get; set; }
}