using System;
using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;


namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleryById
{
    public class GetGalleryByIdQueryHandler : IRequestHandler<GetGalleryByIdQuery, GalleryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryRepository _galleryRepository;
        private readonly IAppLogger<GetGalleryByIdQueryHandler> _logger;

        public GetGalleryByIdQueryHandler(IMapper mapper, 
            IGalleryRepository galleryRepository,
            IAppLogger<GetGalleryByIdQueryHandler> logger)
        {
            this._mapper = mapper;
            this._galleryRepository = galleryRepository;
            this._logger = logger;
        }
        public async Task<GalleryDTO> Handle(GetGalleryByIdQuery request, CancellationToken cancellationToken)
        {
            var gallery = await _galleryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Gallery), request.Id);

            _logger.LogInformation("Gallery retrieved successfully.");
            var data = _mapper.Map<GalleryDTO>(gallery);

            return data;
        }
    }
}
