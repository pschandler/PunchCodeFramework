using System;
using Moq;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PunchcodeStudios.Application.MappingProfiles;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleries;
using PunchcodeStudios.Application.Features.Gallery;
using Shouldly;

namespace PunchcodeStudios.UnitTests.Features.Galleries.Queries;

public class GetGalleriesQueryHandlerTests
{
    private readonly Mock<IGalleryRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetGalleriesQueryHandler>> _mockAppLogger;

    public GetGalleriesQueryHandlerTests()
    {
        _mockRepo = MockGalleryRepository.GetMockGalleryRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<GalleryProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetGalleriesQueryHandler>>();
    }

    [Fact]
    public async Task GetGalleries_WhenCalled_ShouldReturnListOfGalleries()
    {
        var handler = new GetGalleriesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

        var result = await handler.Handle(new GetGalleriesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<GalleryDTO>>();
        result.Count.ShouldBe(3);
    }
}
