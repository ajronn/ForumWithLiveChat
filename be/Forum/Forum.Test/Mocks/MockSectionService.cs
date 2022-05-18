using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Domain.Interface.Service;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Data;
using Moq;

namespace Forum.Test.Mocks
{
    public static class MockSectionService
    {
        public static Mock<ISectionService> CreateSectionService()
        {
            var sections = new List<SectionDto>
            {
                new()
                {
                    SectionId = 1,
                    Name = "Sekcja 1"
                }
            };

            var mockService = new Mock<ISectionService>();
            mockService.Setup(d => d.CreateAsync(It.IsAny<CreateSectionCommand>()))
                .Callback<CreateSectionCommand>((s) => sections.Add(new SectionDto { Name = s.Name})).ReturnsAsync(new SectionDto());

            return mockService;
        }
    }
}