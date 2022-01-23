using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Models.Abstract;
using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Data.Concrete;
public class IdentityRepository : MongoDbRepository<IdentityUser>, IIdentityRepository
{
    public IdentityRepository(IAppSettings settings) : base(settings) { }
}