using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.CategoryGallery.Commands.AddCategoryGallery
{
    public class AddGalleryToCategoryCommandValidator : AbstractValidator<AddGalleryToCategoryCommand>
    {
        public AddGalleryToCategoryCommandValidator()
        {
            RuleFor(p => p.CategoriesId).NotNull().WithMessage("{PropertyName} cannot be null.");
            RuleFor(p => p.GalleriesId).NotNull().WithMessage("{PropertyName} cannot be null.");
        }
    }
}
