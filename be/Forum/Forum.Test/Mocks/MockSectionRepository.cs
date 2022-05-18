using System.Collections.Generic;
using Forum.Domain.Interface.Repository;
using Forum.Transfer.Section.Data;
using Moq;

namespace Forum.Test.Mocks
{
    public static class MockSectionRepository
    {
        public static Mock<ISectionRepository> GetSectionListRepository()
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

        public static Mock<ISectionRepository> GetSectionRepository()
        {
            var section = new SectionDto
            {
                SectionId = 1,
                Name = "Sekcja 1"
            };
            var mockRepo = new Mock<ISectionRepository>();
            mockRepo.Setup(x => x.GetSectionAsync(It.Is<int>(y => y == section.SectionId))).ReturnsAsync(section);

            return mockRepo;
        }
    }
}
