using System.Collections.Generic;
using Forum.Transfer.Section.Data;
using MediatR;

namespace Forum.Transfer.Section.Query
{
    public class GetAllSectionsQuery : IRequest<List<SectionDto>>
    {
    }
}