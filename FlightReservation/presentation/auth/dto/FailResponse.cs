using System.Net;

namespace FlightReservation.presentation.auth.dto;

public class FailResponse
{
    public string? Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}