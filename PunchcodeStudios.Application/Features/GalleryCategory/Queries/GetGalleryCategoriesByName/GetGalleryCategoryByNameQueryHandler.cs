using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategoriesById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategoriesByName
{
    public class GetGalleryCategoryByNameQueryHandler : IRequestHandler<GetGalleryCategoryByNameQuery, GalleryCategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryCategoryRepository _repo;
        private readonly IAppLogger<GetGalleryCategoryByIdQueryHandler> _logger;

        public GetGalleryCategoryByNameQueryHandler(IMapper mapper,
            IGalleryCategoryRepository repo,
            IAppLogger<GetGalleryCategoryByIdQueryHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }

        public async Task<GalleryCategoryDTO> Handle(GetGalleryCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetGalleryCategoryByName(request.name);

            var data = _mapper.Map<GalleryCategoryDTO>(item);

            _logger.LogInformation("Galleries retrieved successfully.");
            return data;
        }
    }
}
