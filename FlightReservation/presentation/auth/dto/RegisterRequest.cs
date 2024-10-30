using System.ComponentModel.DataAnnotations;
using FlightReservation.infra.models;

namespace FlightReservation.presentation.user;

public class RegisterRequest : LoginRequest
{
 
    public required Role Role { get; set; }
}