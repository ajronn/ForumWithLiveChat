using System.Collections.Generic;
using Forum.Transfer.Subsection;

namespace Forum.Transfer.Section
{
    public class SectionDto
    {
        public int SectionId { get; set; }

        public string Name { get; set; }

        public ICollection<SubsectionDto> Subsections { get; set; }
    }
}
