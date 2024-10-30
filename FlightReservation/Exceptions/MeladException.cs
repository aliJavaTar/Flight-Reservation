using FlightReservation.Enums;
using FlightReservation.Middlewares;

namespace FlightReservation.Exceptions;

public class MeladException() : Exception("Errooooooooooooooooooooooooooooor"), IAppException
{
    public int StatusCode => ExceptionEnum.MeladException;
}