using Twitter.Clone.Models.Abstract;

namespace Twitter.Clone.Models.Concrete
{
    public class Follow : MongoDbEntity
    {
        public Follow(string followUserId, string followEmail, string followFullName)
        {
            FollowUserId = followUserId;
            FollowEmail = followEmail;
            FollowFullName = followFullName;
        }

        public string FollowUserId { get; private set; }
        public string FollowEmail { get; private set; }
        public string FollowFullName { get; private set; }
    }
}
