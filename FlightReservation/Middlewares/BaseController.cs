using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.Middlewares;

[Route("[controller]/[action]")]
[ApiController]
[ApiResultFilter]
public class BaseController : ControllerBase
{
}
