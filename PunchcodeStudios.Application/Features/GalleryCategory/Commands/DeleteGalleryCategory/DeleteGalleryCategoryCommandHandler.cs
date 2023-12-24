using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
using PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.DeleteGalleryCategory
{
    public class DeleteGalleryCategoryCommandHandler : IRequestHandler<DeleteGalleryCategoryCommand, bool>
    {

        private readonly IGalleryCategoryRepository _repo;

        public DeleteGalleryCategoryCommandHandler(IMapper mapper, IGalleryCategoryRepository repo)
        {
            this._repo = repo;
        }

        public async Task<bool> Handle(DeleteGalleryCategoryCommand request, CancellationToken cancellationToken)
        {
            // TODO Validate incoming data

            var item = await _repo.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(GalleryCategory), request.Id);

            await _repo.DeleteAsync(item);

            return true;
        }
    }
}
