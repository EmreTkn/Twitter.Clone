using MediatR;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Post.Queries.GetPosts;
public class GetPostsQuery : IRequest<IEnumerable<PostDto>>
{
    public GetPostsQuery(string email, int pageNumber, int? pageSize = null)
    {
        Email = email;
        Skip = (pageSize ?? 5) * (pageNumber - 1);
        Take = pageSize ?? 5;
    }

    public int Skip { get; set; }
    public int Take { get; set; }
    public string Email { get; set; }
}
