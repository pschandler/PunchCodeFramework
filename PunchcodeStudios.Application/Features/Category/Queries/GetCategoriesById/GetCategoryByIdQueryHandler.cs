using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Queries.GetCategoriesById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly IAppLogger<GetCategoryByIdQueryHandler> _logger;

        public GetCategoryByIdQueryHandler(IMapper mapper,
            ICategoryRepository repo,
            IAppLogger<GetCategoryByIdQueryHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetByIdAsync(request.id);

            var data = _mapper.Map<CategoryDTO>(item);

            _logger.LogInformation("Galleries retrieved successfully.");
            return data;
        }
    }
}
