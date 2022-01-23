using Twitter.Clone.Models.Abstract;

namespace Twitter.Clone.Models.Concrete;
public class Like : MongoDbEntity
{
    public Like() { }
    public Like(string likedByUserId, string likedByUserEmail)
    {
        LikedByUserId = likedByUserId;
        LikedByUserEmail = likedByUserEmail;
    }

    public string LikedByUserId { get; private set; }
    public string LikedByUserEmail { get; private set; }
}