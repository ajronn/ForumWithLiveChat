using System.Collections.Generic;
using MediatR;

namespace Forum.Transfer.Section.Query
{
    public class GetAllSectionQuery : IRequest<List<SectionDto>>
    {
    }
}