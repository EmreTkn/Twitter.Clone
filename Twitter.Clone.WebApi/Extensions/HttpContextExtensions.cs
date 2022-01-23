using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Twitter.Clone.WebApi.Extensions;
public static class HttpContextExtensions
{
    public static string GetEmailAddress(this HttpContext context)
        => context.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
    public static string GetRole(this HttpContext context)
    => context.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
}
