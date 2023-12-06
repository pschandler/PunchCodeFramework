using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery
{
    public class DeleteGalleryCommandHandler : IRequestHandler<DeleteGalleryCommand, bool>
    {

        private readonly IGalleryRepository _galleryRepository;

        public DeleteGalleryCommandHandler(IMapper mapper, IGalleryRepository galleryRepository)
        {
            this._galleryRepository = galleryRepository;
        }

        public async Task<bool> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            // TODO Validate incoming data

            var gallery = await _galleryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Gallery), request.Id);

            await _galleryRepository.DeleteAsync(gallery);

            return true;
        }
    }
}
