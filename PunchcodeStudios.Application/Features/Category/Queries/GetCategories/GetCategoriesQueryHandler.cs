using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly IAppLogger<GetCategoriesQueryHandler> _logger;

        public GetCategoriesQueryHandler(IMapper mapper,
            ICategoryRepository repo,
            IAppLogger<GetCategoriesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }

        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var items = await _repo.GetAsync();

            var data = _mapper.Map<List<CategoryDTO>>(items);

            _logger.LogInformation("Galleries retrieved successfully.");
            return data;
        }
    }
}
