using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.CategoryGallery.Commands.AddCategoryGallery
{
    public class AddGalleryToCategoryCommandHandler : IRequestHandler<AddGalleryToCategoryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryGalleryRepository _repo;

        public AddGalleryToCategoryCommandHandler(IMapper mapper, ICategoryGalleryRepository repo)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        public async Task<bool> Handle(AddGalleryToCategoryCommand request, CancellationToken cancellationToken)
        {
            // validation
            var validator = new AddGalleryToCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any()) { throw new BadRequestException("Invalid Gallery Category", validationResult); }

            // add to database
            await _repo.AddGalleryToCategory(request.GalleriesId, request.CategoriesId);

            // return true
            return true;
        }
    }
}
