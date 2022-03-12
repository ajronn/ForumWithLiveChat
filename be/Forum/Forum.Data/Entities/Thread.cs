using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Data.Entities
{
    public class Thread
    {
        [Key] public int ThreadId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SubsectionId { get; set; }

        public Subsection Subsection { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}