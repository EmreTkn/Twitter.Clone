using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Twitter.Clone.Handlers.Behaviours;
using Twitter.Clone.Handlers.Services.Concrete;
using Twitter.Clone.Handlers.Services.Interfaces;

namespace Twitter.Clone.Handlers;
public static class DependencyInjection
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        var assemblies = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assemblies);
        services.AddValidatorsFromAssembly(assemblies, ServiceLifetime.Transient);
        services.AddMediatR(assemblies);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        return services;
    }
}