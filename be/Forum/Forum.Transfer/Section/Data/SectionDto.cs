using System.Collections.Generic;
using Forum.Transfer.Subsection.Data;

namespace Forum.Transfer.Section.Data
{
    public class SectionDto
    {
        public int SectionId { get; set; }

        public string Name { get; set; }

        public ICollection<SubsectionDto> Subsections { get; set; }
    }
}
