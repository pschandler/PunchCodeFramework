using System;
using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;

namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleriesByTypeName;

public class GetGalleriesByTypeNameQueryHandler : IRequestHandler<GetGalleriesByTypeNameQuery, List<GalleryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IGalleryRepository _galleryRepository;
    private readonly IAppLogger<GetGalleriesByTypeNameQueryHandler> _logger;

    public GetGalleriesByTypeNameQueryHandler(IMapper mapper, 
        IGalleryRepository galleryRepository,
        IAppLogger<GetGalleriesByTypeNameQueryHandler> logger)
    {
        this._mapper = mapper;
        this._galleryRepository = galleryRepository;
        this._logger = logger;
    }
    public async  Task<List<GalleryDTO>> Handle(GetGalleriesByTypeNameQuery request, CancellationToken cancellationToken)
    {
        var gallery = await _galleryRepository.GetGalleriesByTypeName(request.TypeName) ?? throw new NotFoundException(nameof(Gallery), request.TypeName);

        _logger.LogInformation("Galleries retrieved successfully.");
        var data = _mapper.Map<List<GalleryDTO>>(gallery);

        return data;
    }
}