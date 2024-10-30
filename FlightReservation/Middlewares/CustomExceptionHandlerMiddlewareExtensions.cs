using System.Net;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace FlightReservation.Middlewares;

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}

public class CustomExceptionHandlerMiddleware(
    RequestDelegate next,
    IHostEnvironment env,
    ILogger<CustomExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        string message = null!;
        var httpStatusCode = HttpStatusCode.InternalServerError;
        var apiStatusCode = ApiResultStatusCode.ServerError;
        try
        {
            await next(context);
        }
        catch (AppException exception)
        {
            logger.LogError(exception, exception.Message);
            httpStatusCode = exception.HttpStatusCode;
            apiStatusCode = exception.ApiStatusCode;
#if DEBUG

            var dic = new Dictionary<string, string>
            {
                ["Exception"] = exception.Message, ["StackTrace"] = exception.StackTrace!
            };
            if (exception.InnerException != null)
            {
                dic.Add("InnerException.Exception", exception.InnerException.Message);
                dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace!);
            }

            if (exception.AdditionalData != null)
                dic.Add("AdditionalData", JsonSerializer.Serialize(exception.AdditionalData));

            message = JsonSerializer.Serialize(dic);
#endif

# if !DEBUG
                message = exception.Message;
#endif
            await WriteToResponseAsync();
        }
        catch (SecurityTokenExpiredException exception)
        {
            logger.LogError(exception, exception.Message);
            SetUnAuthorizeResponse(exception);
            await WriteToResponseAsync();
        }
        catch (UnauthorizedAccessException exception)
        {
            logger.LogError(exception, exception.Message);
            SetUnAuthorizeResponse(exception);
            await WriteToResponseAsync();
        }
        catch (Exception exception)
        {
            IAppException domainException = (exception as IAppException)!;
            if (domainException != null)
            {
                httpStatusCode = (HttpStatusCode)domainException.StatusCode;
                message = exception.Message;
                apiStatusCode = (ApiResultStatusCode)domainException.StatusCode;
            }

            logger.LogError(exception, exception.Message);
#if DEBUG

            var dic = new Dictionary<string, string>
            {
                ["Exception"] = $"{message} {exception.Message}", ["StackTrace"] = exception.StackTrace!
            };
            message = JsonSerializer.Serialize(dic);
#endif
            await WriteToResponseAsync();
        }

        async Task WriteToResponseAsync()
        {
            if (context.Response.HasStarted)
                throw new InvalidOperationException(
                    "The response has already started, the http status code middleware will not be executed.");

            var result = new ApiResult(false, apiStatusCode, message);

            var json = JsonSerializer.Serialize(result,  new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }

        void SetUnAuthorizeResponse(Exception exception)
        {
            httpStatusCode = HttpStatusCode.Unauthorized;
            apiStatusCode = ApiResultStatusCode.UnAuthorized;

            if (env.IsDevelopment())
            {
                var dic = new Dictionary<string, string>
                {
                    ["Exception"] = exception.Message, ["StackTrace"] = exception.StackTrace!
                };
                if (exception is SecurityTokenExpiredException tokenException)
                    dic.Add("Expires", tokenException.Expires.ToString());

                message = JsonSerializer.Serialize(dic);
            }
        }
    }
}