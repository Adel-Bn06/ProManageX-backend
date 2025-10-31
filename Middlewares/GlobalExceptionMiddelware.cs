using SmartTasks.Exceptions;
using System.Net;
using System.Text.Json;

namespace SmartTasks.Middlewares;

public class GlobalExceptionMiddelware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = HttpStatusCode.InternalServerError;

        if (ex is NotFoundException)
            statusCode = HttpStatusCode.NotFound;
        else if (ex is Exceptions.ValidationException)
            statusCode = HttpStatusCode.BadRequest;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = JsonSerializer.Serialize(new
        {
            message = ex.Message
        });

        return context.Response.WriteAsync(response);
    }
}
