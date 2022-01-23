using Twitter.Clone.Models.Abstract;

namespace Twitter.Clone.Models.Concrete;
public class Post : MongoDbEntity
{
    public Post(User createdBy, string content)
    {
        CreatedBy = createdBy;
        Content = content;
    }
    public Post() { }
    public User CreatedBy { get; private set; }
    public List<Like> Likes { get; private set; } = new();
    public string Content { get; private set; }

    public void AddLike(string userId, string userMail)
        => Likes.Add(new Like(userId, userMail));
}