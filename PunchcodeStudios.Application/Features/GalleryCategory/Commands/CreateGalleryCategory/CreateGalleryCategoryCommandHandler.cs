using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Exceptions;
using PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.CreateGalleryCategory
{
    public class CreateGalleryCategoryCommandHandler : IRequestHandler<CreateGalleryCategoryCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryCategoryRepository _repo;

        public CreateGalleryCategoryCommandHandler(IMapper mapper, IGalleryCategoryRepository repo)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        public async  Task<Guid> Handle(CreateGalleryCategoryCommand request, CancellationToken cancellationToken)
        {
            // validation
            var validator = new CreateGalleryCategoryCommandValidator(_repo);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.Errors.Any()) { throw new BadRequestException("Invalid Gallery Category", validationResult); }

            // convert valid data to entity object
            var category = _mapper.Map<Domain.GalleryCategory>(request);

            // add to database
            await _repo.CreateAsync(category);

            // return id
            return category.Id;
        }
    }
}
