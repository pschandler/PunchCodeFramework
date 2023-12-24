using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategories
{
    public class GetGalleryCategoriesQueryHandler : IRequestHandler<GetGalleryCategoriesQuery, List<GalleryCategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryCategoryRepository _repo;
        private readonly IAppLogger<GetGalleryCategoriesQueryHandler> _logger;

        public GetGalleryCategoriesQueryHandler(IMapper mapper,
            IGalleryCategoryRepository repo,
            IAppLogger<GetGalleryCategoriesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }

        public async Task<List<GalleryCategoryDTO>> Handle(GetGalleryCategoriesQuery request, CancellationToken cancellationToken)
        {
            var items = await _repo.GetAsync();

            var data = _mapper.Map<List<GalleryCategoryDTO>>(items);

            _logger.LogInformation("Galleries retrieved successfully.");
            return data;
        }
    }
}
