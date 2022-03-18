using System.Collections.Generic;
using Forum.Transfer.Post.Data;
using Forum.Transfer.Subsection.Data;

namespace Forum.Transfer.Thread.Data
{
    public class ThreadDto
    {
        public int ThreadId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SubsectionDto Subsection { get; set; }

        public ICollection<PostDto> Posts { get; set; }
    }
}