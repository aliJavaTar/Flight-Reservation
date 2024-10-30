using System.ComponentModel.DataAnnotations;

namespace FlightReservation.Middlewares;

public enum ApiResultStatusCode
{
    [Display(Name = "عملیات با موفقیت انجام شد")] Success = 200,
    [Display(Name = "خطایی در سرور رخ داده است")] ServerError = 600,
    [Display(Name = "پارامتر های ارسالی معتبر نیستند")] BadRequest = 603,
    [Display(Name = "یافت نشد")] NotFound = 609,
    [Display(Name = "خطای احراز هویت")] UnAuthorized = 618
}

