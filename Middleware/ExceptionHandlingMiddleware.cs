using System.Net;
using System.Text.Json;
using Task_Manager_API_Backend.Exceptions;

namespace Task_Manager_API_Backend.Middleware;
/// <summary>
/// Этот middleware перехватывает все необработанные исключения в пайплайне,
/// логирует их и преобразует в корректные
/// HTTP-ответы в JSON-формате.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        var statusCode = exception switch
        {
            ValidationException   => StatusCodes.Status400BadRequest,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            ForbiddenException    => StatusCodes.Status403Forbidden,
            NotFoundException     => StatusCodes.Status404NotFound,
            _                     => StatusCodes.Status500InternalServerError
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            statusCode,
            message = exception.Message
        };

        return context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }
}