using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.CategoryGallery.Queries.GetCategoryGalleries
{
    public class GetCategoryGalleriesQueryHandler : IRequestHandler<GetCategoryGalleriesQuery, List<CategoryGalleryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryGalleryRepository _repo;
        private readonly IAppLogger<GetCategoryGalleriesQueryHandler> _logger;

        public GetCategoryGalleriesQueryHandler(IMapper mapper,
            ICategoryGalleryRepository repo,
            IAppLogger<GetCategoryGalleriesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }

        public async Task<List<CategoryGalleryDTO>> Handle(GetCategoryGalleriesQuery request, CancellationToken cancellationToken)
        {
            var items = await _repo.GetAsync();

            var data = _mapper.Map<List<CategoryGalleryDTO>>(items);

            _logger.LogInformation("CategoryGalleries retrieved successfully.");
            return data;
        }
    }
}
