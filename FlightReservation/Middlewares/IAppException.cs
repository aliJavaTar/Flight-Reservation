namespace FlightReservation.Middlewares;

public interface IAppException
{
    int StatusCode { get; }
}
