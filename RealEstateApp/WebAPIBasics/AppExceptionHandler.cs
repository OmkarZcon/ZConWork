using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace RealEstate.Api
{

    // Global Exception Handler With IExceptionHandler
    public class AppExceptionHandler : IExceptionHandler
    {
      private readonly ILogger<AppExceptionHandler> _logger;
        public AppExceptionHandler(ILogger<AppExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception  occurred");

            var errorResponse = new ErrorResponse
            {
                Message = exception.Message
            };

            switch (exception)
            {
                case BadHttpRequestException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Title = exception.GetType().Name;
                    break;

                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Title = "InternalServer Error";
                    break;

            }

            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;

        }
    }
}
