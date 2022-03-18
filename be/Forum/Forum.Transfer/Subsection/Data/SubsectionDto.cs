using System.Collections.Generic;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Thread.Data;

namespace Forum.Transfer.Subsection.Data
{
    public class SubsectionDto
    {
        public int SubsectionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SectionDto Section { get; set; }

        public ICollection<ThreadDto> Threads { get; set; }
    }
}