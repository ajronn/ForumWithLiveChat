using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Data.Entities;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Section.Data;
using Moq;

namespace Forum.Test.Mocks
{
    public static class MockSectionRepository
    {
        public static Mock<ISectionRepository> GetSectionRepository()
        {
            var sections = new List<SectionDto>
            {
                new SectionDto
                {
                    SectionId = 1,
                    Name = "Sekcja 1"
                },
                new SectionDto
                {
                    SectionId = 2,
                    Name = "Sekcja 2"
                },
                new SectionDto
                {
                    SectionId = 3,
                    Name = "Sekcja 3"
                }
            };

            var mockRepo = new Mock<ISectionRepository>();
            mockRepo.Setup(r => r.GetSectionListAsync()).ReturnsAsync(sections);

            return mockRepo;
        }
    }
}
