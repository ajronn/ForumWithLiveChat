using System.Collections.Generic;
using Forum.Transfer.Subsection.Data;
using MediatR;

namespace Forum.Transfer.Subsection.Query
{
    public class GetAllSubsectionsQuery : IRequest<List<SubsectionDto>>
    {
    }
}