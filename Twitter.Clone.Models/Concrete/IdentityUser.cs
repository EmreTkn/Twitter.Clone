using MongoDB.Bson.Serialization.Attributes;
using Twitter.Clone.Models.Abstract;

namespace Twitter.Clone.Models.Concrete;
public class IdentityUser : MongoDbEntity
{
    [BsonElement("Email")]
    public string Email { get; set; }

    [BsonElement("Password")]
    public string Password { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
}