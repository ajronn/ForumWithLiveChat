using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Service;
using Forum.Handler.Section;
using Forum.Test.Mocks;
using Forum.Transfer.Section.Command;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Section.Query;
using Moq;
using Shouldly;
using Xunit;

namespace Forum.Test.Section.Commands
{
    public class CreateSectionHandlerTests
    {
        private readonly Mock<ISectionService> _mockService;
        public CreateSectionHandlerTests()
        {
            _mockService = MockSectionService.CreateSectionService();

        }

        [Fact]
        public async Task Create_Section()
        {
            var handler = new SectionCommandHandler(_mockService.Object);

            var result = await handler.Handle(new CreateSectionCommand{Name = "Sekcja 2"}, CancellationToken.None);

            result.ShouldNotBeNull();
        }
    }
}
