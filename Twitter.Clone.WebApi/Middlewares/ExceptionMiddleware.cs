using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter.Clone.WebApi.Errors;

namespace Twitter.Clone.WebApi.Middlewares;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;
    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await CreateExceptionResponse(context, ex.Message, 401);
        }
        catch (System.Exception ex) when (_env.IsDevelopment() && ex.GetType() != typeof(ValidationException))
        {
            await CreateExceptionResponse(context, ex.Message);
        }
        catch (System.Exception ex) when (!_env.IsDevelopment() && ex.GetType() != typeof(ValidationException))
        {
            await CreateExceptionResponse(context, "Invalid request");
        }
    }

    private static async Task CreateExceptionResponse(HttpContext context, string exceptionMessage, int? statusCode = null)
    {
        var status = statusCode ?? (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = status;
        var message = exceptionMessage.Replace("\r\n -- ", "").Replace(" Severity: Error", "");
        var response = new ApiResponse(status, message);
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}