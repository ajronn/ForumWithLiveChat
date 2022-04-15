using AutoMapper;
using Forum.Data.Entities;
using Forum.Transfer.Post.Data;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Subsection.Data;
using Forum.Transfer.Thread.Data;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;

namespace Forum.Data.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Section, SectionDto>().ReverseMap();
            CreateMap<Subsection, SubsectionDto>().ReverseMap();
            CreateMap<Thread, ThreadDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserBasicDto>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ForMember(user => user.UserName,
                map => map.MapFrom(dto => dto.Email));
        }
    }
}
