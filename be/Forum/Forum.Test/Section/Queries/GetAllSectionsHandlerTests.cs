using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Data.Mapping;
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
    public class GetAllSectionsHandlerTests
    {
        private readonly Mock<ISectionRepository> _mockRepo;
        public GetAllSectionsHandlerTests()
        {
            _mockRepo = MockSectionRepository.GetSectionListRepository();

        }

        [Fact]
        public async Task Get_Section_List_Test()
        {
            var handler = new SectionQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetAllSectionsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<SectionDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
