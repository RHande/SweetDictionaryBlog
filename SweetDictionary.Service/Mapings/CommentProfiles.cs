using AutoMapper;
using SweetDictionary.Models.Comments;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Service.Mapings;

public class CommentProfiles : Profile
{
    public CommentProfiles()
    {
        CreateMap<CreateCommentRequestDto, Comment>();
        CreateMap<Comment, CommentResponseDto>()
            .ForMember(x => x.PostTitle, opt => opt.MapFrom(x => x.Post.Title))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));
    }
}
