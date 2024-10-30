using FlightReservation.infra.models;
using FlightReservation.presentation.user;

namespace FlightReservation.presentation.auth.dto;

public class RegisterRequest : LoginRequest
{
 
    public required Role Role { get; set; }
}