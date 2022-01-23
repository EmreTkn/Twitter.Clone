using Microsoft.Extensions.Configuration;

namespace Twitter.Clone.CompositionRoot.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetValue(this IConfiguration configuration, string section, string key)
            => configuration[$"{section}:{key}"];
    }
}