using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forum.Domain.Interface.Repository;
using Forum.Handler.Section;
using Forum.Test.Mocks;
using Forum.Transfer.Section.Data;
using Forum.Transfer.Section.Query;
using Moq;
using Shouldly;
using Xunit;

namespace Forum.Test.Section.Queries
{
    public class GetSectionHandlerTests
    {
        private readonly Mock<ISectionRepository> _mockRepo;
        public GetSectionHandlerTests()
        {
            _mockRepo = MockSectionRepository.GetSectionRepository();

        }

        [Fact]
        public async Task Get_Section_Not_Be_Null_Test()
        {
            var handler = new SectionQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetSectionQuery(1), CancellationToken.None);

            result.ShouldBeOfType<SectionDto>();

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Get_Section_Null_Test()
        {
            var handler = new SectionQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetSectionQuery(2), CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
