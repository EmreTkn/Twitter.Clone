using Microsoft.Extensions.Configuration;
using Twitter.Clone.CompositionRoot.Extensions;

namespace Twitter.Clone.CompositionRoot.Concrete
{
    public class AppSettings
    {
        private readonly IConfiguration _configuration;
        public AppSettings(IConfiguration configuration) => _configuration = configuration;
        public string MongoConnectionString => _configuration.GetValue("App", "MongoDbConnectionString");
    }
}
