using Microsoft.Extensions.Configuration;
using Twitter.Clone.Models.Abstract;

namespace Twitter.Clone.Models.Concrete;
public class AppSettings : IAppSettings
{
    private readonly IConfiguration _configuration;
    public AppSettings(IConfiguration configuration) => _configuration = configuration;
    public string MongoDbConnectionString => _configuration["App:MongoDbConnectionString"];
    public string MongoDbDatabase => _configuration["App:MongoDbDatabase"];
    public string RedisConnectionString => _configuration["App:RedisConnectionString"];
    public string TokenSecretKey => _configuration["Token:SecretKey"];
    public string TokenIssuer => _configuration["Token:Issuer"];
}