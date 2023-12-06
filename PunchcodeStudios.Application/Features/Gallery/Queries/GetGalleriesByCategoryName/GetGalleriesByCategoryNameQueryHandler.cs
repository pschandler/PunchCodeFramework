using System;
using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;

namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleriesByCategoryName;

public class GetGalleriesByCategoryNameQueryHandler : IRequestHandler<GetGalleriesByCategoryNameQuery, List<GalleryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IGalleryRepository _galleryRepository;
    private readonly IAppLogger<GetGalleriesByCategoryNameQueryHandler> _logger;

    public GetGalleriesByCategoryNameQueryHandler(IMapper mapper, 
        IGalleryRepository galleryRepository,
        IAppLogger<GetGalleriesByCategoryNameQueryHandler> logger)
    {
        this._mapper = mapper;
        this._galleryRepository = galleryRepository;
        this._logger = logger;
    }
    public async Task<List<GalleryDTO>> Handle(GetGalleriesByCategoryNameQuery request, CancellationToken cancellationToken)
    {
        var gallery = await _galleryRepository.GetGalleriesByCategoryName(request.CategoryName) ?? throw new NotFoundException(nameof(Gallery), request.CategoryName);

        var data = _mapper.Map<List<GalleryDTO>>(gallery);

        _logger.LogInformation("Galleries retrieved successfully.");
        return data;
    }

}
