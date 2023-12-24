using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery
{
    public class CreateGalleryCommandValidator : AbstractValidator<CreateGalleryCommand>
    {
        private readonly IGalleryRepository _repo;

        public CreateGalleryCommandValidator(IGalleryRepository repo)
        {
            this._repo = repo;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} has a maximum length of 50.");
            RuleFor(p => p.Description)
                .MaximumLength(100).WithMessage("{PropertyName} has a maximum length of 100.");
            RuleFor(q => q)
                .MustAsync(GalleryNameUnique).WithMessage("Gallery already exists.");
        }

        private Task<bool> GalleryNameUnique(CreateGalleryCommand command, CancellationToken token)
        {
            return _repo.GalleryIsUnique(command.Name);
        }
    }
}
