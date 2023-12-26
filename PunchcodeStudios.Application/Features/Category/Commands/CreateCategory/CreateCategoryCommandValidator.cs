using FluentValidation;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repo;
        public CreateCategoryCommandValidator(ICategoryRepository repo)
        {
            this._repo = repo;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} has a maximum length of 50.");
            RuleFor(p => p.Description)
                .MaximumLength(100).WithMessage("{PropertyName} has a maximum length of 100.");
            RuleFor(q => q)
                .MustAsync(CategoryNameUnique).WithMessage("Category already exists.");
        }

        private Task<bool> CategoryNameUnique(CreateCategoryCommand command, CancellationToken token)
        {
            return _repo.CategoryIsUnique(command.Name);
        }
    }
}
