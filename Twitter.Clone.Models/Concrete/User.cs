using Twitter.Clone.Models.Abstract;

namespace Twitter.Clone.Models.Concrete;
public class User : MongoDbEntity
{
    public User(string applicationUserId, string fullName, string username, string email)
    {
        ApplicationUserId = applicationUserId;
        FullName = fullName;
        Username = username;
        Email = email;
    }
    public User() { }
    public string ApplicationUserId { get; private set; }
    public string FullName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public List<Follow> Followeds { get; private set; } = new();
    public List<Follow> Followers { get; private set; } = new();

    public void AddFollowed(Follow follow) => Followeds.Add(follow);
    public void AddFollower(Follow follow) => Followers.Add(follow);
}