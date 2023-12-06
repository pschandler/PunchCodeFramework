using System;
using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleryByName;

public class GetGalleryByNameQueryHandler : IRequestHandler<GetGalleryByNameQuery, GalleryDTO>
{
    private readonly IMapper _mapper;
    private readonly IGalleryRepository _galleryRepository;
    private readonly IAppLogger<GetGalleryByNameQueryHandler> _logger;

    public GetGalleryByNameQueryHandler(IMapper mapper, 
        IGalleryRepository galleryRepository,
        IAppLogger<GetGalleryByNameQueryHandler> logger)
    {
        this._mapper = mapper;
        this._galleryRepository = galleryRepository;
        this._logger = logger;
    }

    public async Task<GalleryDTO> Handle(GetGalleryByNameQuery request, CancellationToken cancellationToken)
    {
        var gallery = await _galleryRepository.GetGalleryByName(request.Name) ?? throw new NotFoundException(nameof(Gallery), request.Name);

        _logger.LogInformation("Gallery retrieved successfully.");
        var data = _mapper.Map<GalleryDTO>(gallery);

        return data;
    }
}
