using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Subsection
    {
        [Key] public int SubsectionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; }

        public ICollection<Thread> Threads { get; set; }
    }
}