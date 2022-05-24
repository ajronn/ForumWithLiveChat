using System.Collections.Generic;
using AutoMapper;
using Forum.Data.Entities;
using Forum.Transfer.Chat;
using Forum.Transfer.Chat.Data;
using Forum.Transfer.Post.Data;
using Forum.Transfer.Role.Data;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Shared;
using Forum.Transfer.Subsection.Data;
using Forum.Transfer.Thread.Data;
using Forum.Transfer.User.Command;
using Forum.Transfer.User.Data;
using Microsoft.AspNetCore.Identity;

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
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<PageListDto<MessageDto>, PageListDto<Message>>().ReverseMap();
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
        }
    }
}
