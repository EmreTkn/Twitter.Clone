namespace Twitter.Clone.Models.Abstract;

public interface IAppSettings
{
    public string MongoDbConnectionString { get; }
    public string MongoDbDatabase { get; }
    public string TokenSecretKey { get; }
    public string TokenIssuer { get; }
    public string RedisConnectionString { get; }
    
}