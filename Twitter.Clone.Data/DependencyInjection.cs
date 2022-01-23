using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Data.Concrete;
using Twitter.Clone.Models.Abstract;
using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Data;
public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAppSettings>(provider => new AppSettings(configuration));
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        return services;
    }
}