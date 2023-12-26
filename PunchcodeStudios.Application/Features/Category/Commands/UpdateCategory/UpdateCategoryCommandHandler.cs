using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly IAppLogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(IMapper mapper,
            ICategoryRepository repo,
            IAppLogger<UpdateCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryCommandValidator(_repo);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}",
                    nameof(Gallery), request.Id);
            }

            var item = _mapper.Map<Domain.Category>(request);

            await _repo.UpdateAsync(item);

            return true;
        }
    }
}
