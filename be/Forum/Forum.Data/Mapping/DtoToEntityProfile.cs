using AutoMapper;
using Forum.Data.Entities;
using Forum.Transfer.Post.Data;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Subsection.Data;
using Forum.Transfer.Thread.Data;

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
        }
    }
}
