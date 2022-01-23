using AutoMapper;
using MediatR;
using Twitter.Clone.Data.Abstract;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Post.Queries.GetPosts;
public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IEnumerable<PostDto>>
{
    readonly IMapper _mapper;
    readonly IPostRepository _postRepository;
    readonly IUserRepository _userRepository;

    public GetPostsQueryHandler(IMapper mapper, IPostRepository postRepository, IUserRepository userRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Email == request.Email);
        var followedIds = user?.Followeds?.Select(x => x.FollowUserId);
        var posts = followedIds == null ?
            _postRepository
            .Get()
            .Skip(request.Skip)
            .Take(request.Take)
            .Select(_mapper.Map<PostDto>)
            :
            _postRepository
            .Get()
            .ToList()
            .OrderBy(x => followedIds.Any(id => id == x.CreatedBy.Id) ? 0 : 1)
            .Skip(request.Skip)
            .Take(request.Take)
            .Select(_mapper.Map<PostDto>);
        return posts;
    }
}
