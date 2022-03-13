using AutoMapper;
using Forum.Data.Entities;
using Forum.Transfer.Section;

namespace Forum.Data.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Section, SectionDto>().ReverseMap();
        }
    }
}
