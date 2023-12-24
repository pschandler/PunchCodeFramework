using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.DeleteGalleryCategory
{
    public class DeleteGalleryCategoryCommandValidator : AbstractValidator<DeleteGalleryCategoryCommand>
    {
        private readonly IGalleryCategoryRepository _repo;

        public DeleteGalleryCategoryCommandValidator(IGalleryCategoryRepository repo)
        {
            this._repo = repo;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(GalleryCategoryExists);
        }

        private async Task<bool> GalleryCategoryExists(Guid id, CancellationToken token)
        {
            var category = await _repo.GetByIdAsync(id);
            return category != null;
        }
    }
}
