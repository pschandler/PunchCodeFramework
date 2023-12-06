using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.UpdateGallery
{
    public class UpdateGalleryCommandHandler : IRequestHandler<UpdateGalleryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryRepository _galleryRepository;
        private readonly IAppLogger<UpdateGalleryCommandHandler> _logger;

        public UpdateGalleryCommandHandler(IMapper mapper, 
            IGalleryRepository galleryRepository,
            IAppLogger<UpdateGalleryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._galleryRepository = galleryRepository;
            this._logger = logger;
        }
        public async Task<bool> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGalleryCommandValidator(_galleryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}",
                    nameof(Gallery), request.Id);
            }

            var gallery = _mapper.Map<Domain.Gallery>(request);

            await _galleryRepository.UpdateAsync(gallery);

            return true;
        }
    }
}
