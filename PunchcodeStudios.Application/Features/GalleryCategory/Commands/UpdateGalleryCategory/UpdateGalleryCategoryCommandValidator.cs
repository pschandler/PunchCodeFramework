using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.UpdateGalleryCategory
{
    public class UpdateGalleryCategoryCommandValidator : AbstractValidator<UpdateGalleryCategoryCommand>
    {
        private readonly IGalleryCategoryRepository _repo;

        public UpdateGalleryCategoryCommandValidator(IGalleryCategoryRepository repo)
        {
            this._repo = repo;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(GalleryExists);
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} has a maximum length of 50.");
            RuleFor(p => p.Description)
                .MaximumLength(100).WithMessage("{PropertyName} has a maximum length of 100.");
            RuleFor(p => p.DateCreated)
                .NotNull().WithMessage("{PropertyName} is required.");
        }

        private async Task<bool> GalleryExists(Guid id, CancellationToken token)
        {
            var item = await _repo.GetByIdAsync(id);
            return item != null;
        }
    }
}
