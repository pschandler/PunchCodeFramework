using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Features.Gallery.Commands.DeleteGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public DeleteCategoryCommandValidator(ICategoryRepository repo)
        {
            this._repo = repo;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(CategoryExists);
        }

        private async Task<bool> CategoryExists(Guid id, CancellationToken token)
        {
            var category = await _repo.GetByIdAsync(id);
            return category != null;
        }
    }
}
