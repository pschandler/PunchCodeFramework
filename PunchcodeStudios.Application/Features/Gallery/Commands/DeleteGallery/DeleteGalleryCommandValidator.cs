using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery
{
    public class DeleteGalleryCommandValidator : AbstractValidator<DeleteGalleryCommand>
    {
        private readonly IGalleryRepository _galleryRepository;

        public DeleteGalleryCommandValidator(IGalleryRepository galleryRepository)
        {
            this._galleryRepository = galleryRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(GalleryExists);
        }

        private async Task<bool> GalleryExists(Guid id, CancellationToken token)
        {
            var gallery = await _galleryRepository.GetByIdAsync(id);
            return gallery != null;
        }
    }
}
