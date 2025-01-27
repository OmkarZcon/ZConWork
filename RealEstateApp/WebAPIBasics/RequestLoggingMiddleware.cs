using Microsoft.AspNetCore.Http;
using RealEstate.core;
using System.Threading.Tasks;


// Namespace for FileLogger

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the incoming request path
        FileLogger.Log($"Incoming request: {context.Request.Method} {context.Request.Path}");

        // Call the next middleware
        await _next(context);

        // Log the response status code
        FileLogger.Log($"Response status code: {context.Response.StatusCode}");
    }
}
