using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.UpdateGallery
{
    public class UpdateGalleryCommandValidator : AbstractValidator<UpdateGalleryCommand>
    {
        private readonly IGalleryRepository _galleryRepository;

        public UpdateGalleryCommandValidator(IGalleryRepository galleryRepository)
        {
            this._galleryRepository = galleryRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(GalleryExists);
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(75).WithMessage("{PropertyName} has a maximum length of 75.");
            RuleFor(p => p.Description)
                .MaximumLength(100).WithMessage("{PropertyName} has a maximum length of 100.");
            RuleFor(p => p.DateCreated)
                .NotNull().WithMessage("{PropertyName} is required.");
        }

        private async Task<bool> GalleryExists(Guid id, CancellationToken token)
        {
            var gallery = await _galleryRepository.GetByIdAsync(id);
            return gallery != null;
        }
    }
}
