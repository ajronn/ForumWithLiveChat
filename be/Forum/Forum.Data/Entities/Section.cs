using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Section
    {
        [Key] public int SectionId { get; set; }

        public string Name { get; set; }

        public ICollection<Subsection> Subsections { get; set; }
    }
}