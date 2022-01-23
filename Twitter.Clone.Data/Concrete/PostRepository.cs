using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Models.Abstract;
using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Data.Concrete;
public class PostRepository : MongoDbRepository<Post>, IPostRepository
{
    public PostRepository(IAppSettings settings) : base(settings) { }
}
