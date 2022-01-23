using Microsoft.Extensions.DependencyInjection;
using Twitter.Clone.CompositionRoot.Concrete;
using Twitter.Clone.Core.Interfaces;
using Twitter.Clone.Core.Services;
using Twitter.Clone.Handlers;

namespace Twitter.Clone.CompositionRoot
{
    public static class Setup
    {
        public static void InitializeRoot(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
