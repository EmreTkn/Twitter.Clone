using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Twitter.Clone.CompositionRoot2.Exception;

namespace Twitter.Clone.CompositionRoot.Middlewares;
public class ExceptionMiddlerware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddlerware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var response = new ApiResponse((int)HttpStatusCode.BadRequest, ex.Message);
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }

}

