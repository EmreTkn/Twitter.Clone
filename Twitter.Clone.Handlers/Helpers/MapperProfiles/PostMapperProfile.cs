using AutoMapper;
using Twitter.Clone.Handlers.DTOs;

namespace Twitter.Clone.Handlers.Helpers.MapperProfiles;
public class PostMapperProfile : Profile
{
    public PostMapperProfile()
    {
        CreateMap<Models.Concrete.Post, PostDto>()
            .ForMember(dst => dst.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dst => dst.CreatedEmail, opt => opt.MapFrom(src => src.CreatedBy.Email))
            .ReverseMap();
    }
}