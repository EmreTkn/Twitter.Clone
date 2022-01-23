using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Twitter.Clone.WebApi.Extensions;

namespace Twitter.Clone.WebApi.Middlewares;
public class SecurityMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var currentPath = context.Request.Path.Value;
        if (currentPath.Contains("like") || currentPath.Contains("create") || currentPath.Contains("follow"))
        {
            if (context.GetRole() != "User")
            {
                throw new ValidationException("Guest users cannot share or like a post. Also cannot follow any user.");
            }
        }
        await _next(context);
    }
}