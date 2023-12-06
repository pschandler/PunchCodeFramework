using System;
using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;

namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleries;

public class GetGalleriesQueryHandler : IRequestHandler<GetGalleriesQuery, List<GalleryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IGalleryRepository _galleryRepository;
    private readonly IAppLogger<GetGalleriesQueryHandler> _logger;

    public GetGalleriesQueryHandler(IMapper mapper, 
        IGalleryRepository galleryRepository, 
        IAppLogger<GetGalleriesQueryHandler> logger)
    {
        this._mapper = mapper;
        this._galleryRepository = galleryRepository;
        this._logger = logger;
    }

    public IMapper Mapper { get; }
    public IGalleryRepository GalleryRepository { get; }

    public async Task<List<GalleryDTO>> Handle(GetGalleriesQuery request, CancellationToken cancellationToken)
    {
        var galleries = await _galleryRepository.GetAsync();

        var data = _mapper.Map<List<GalleryDTO>>(galleries);

        _logger.LogInformation("Galleries retrieved successfully.");
        return data;
    }
}
