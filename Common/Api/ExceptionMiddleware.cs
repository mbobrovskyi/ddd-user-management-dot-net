using System.Text.Json;
using Common.Errors;
using Common.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Common.Api;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (HttpError httpError)
        {
            await HandleException(context, httpError);
        }
        catch (Exception exception)
        {
            await HandleException(context, new UndefinedError(exception));
        }
    }

    public async Task HandleException(HttpContext context, HttpError httpError)
    {
        var response = new ErrorResponse
        {
            Code = httpError.Code,
            Message = httpError.Message,
            MetaData = httpError.MetaData,
        };
        
        var options = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpError.HttpStatusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }
}