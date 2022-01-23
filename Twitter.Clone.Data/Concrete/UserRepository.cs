using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Models.Abstract;
using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Data.Concrete;
public class UserRepository : MongoDbRepository<User>, IUserRepository
{
    public UserRepository(IAppSettings settings) : base(settings) { }
}