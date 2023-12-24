using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.CreateGalleryCategory
{
    public class CreateGalleryCategoryCommandValidator : AbstractValidator<CreateGalleryCategoryCommand>
    {
        private readonly IGalleryCategoryRepository _repo;
        public CreateGalleryCategoryCommandValidator(IGalleryCategoryRepository repo)
        {
            this._repo = repo;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} has a maximum length of 50.");
            RuleFor(p => p.Description)
                .MaximumLength(100).WithMessage("{PropertyName} has a maximum length of 100.");
            RuleFor(q => q)
                .MustAsync(GalleryCategoryNameUnique).WithMessage("GalleryCategory already exists.");
        }

        private Task<bool> GalleryCategoryNameUnique(CreateGalleryCategoryCommand command, CancellationToken token)
        {
            return _repo.GalleryCategoryIsUnique(command.Name);
        }
    }
}
