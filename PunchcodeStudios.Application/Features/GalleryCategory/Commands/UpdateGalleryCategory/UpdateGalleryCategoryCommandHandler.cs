using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.UpdateGalleryCategory
{
    public class UpdateGalleryCategoryCommandHandler : IRequestHandler<UpdateGalleryCategoryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryCategoryRepository _repo;
        private readonly IAppLogger<UpdateGalleryCategoryCommandHandler> _logger;

        public UpdateGalleryCategoryCommandHandler(IMapper mapper,
            IGalleryCategoryRepository repo,
            IAppLogger<UpdateGalleryCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }
        public async Task<bool> Handle(UpdateGalleryCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGalleryCategoryCommandValidator(_repo);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}",
                    nameof(Gallery), request.Id);
            }

            var item = _mapper.Map<Domain.GalleryCategory>(request);

            await _repo.UpdateAsync(item);

            return true;
        }
    }
}
