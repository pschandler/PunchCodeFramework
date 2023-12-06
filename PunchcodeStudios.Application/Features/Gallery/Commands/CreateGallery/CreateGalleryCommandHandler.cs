using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery
{
    public class CreateGalleryCommandHandler : IRequestHandler<CreateGalleryCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryRepository _galleryRepository;

        public CreateGalleryCommandHandler(IMapper mapper, IGalleryRepository galleryRepository)
        {
            this._mapper = mapper;
            this._galleryRepository = galleryRepository;
        }
        public async Task<Guid> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
        {
            // validation
            var validator = new CreateGalleryCommandValidator(_galleryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.Errors.Any()) { throw new BadRequestException("Invalid Gallery", validationResult); }

            // convert valid data to entity object
            var gallery = _mapper.Map<Domain.Gallery>(request);

            // add to database
            await _galleryRepository.CreateAsync(gallery);

            // return id
            return gallery.Id;
        }
    }
}
