using AutoMapper;
using MediatR;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Contracts.Persisitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategoriesById
{
    public class GetGalleryCategoryByIdQueryHandler : IRequestHandler<GetGalleryCategoryByIdQuery, GalleryCategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IGalleryCategoryRepository _repo;
        private readonly IAppLogger<GetGalleryCategoryByIdQueryHandler> _logger;

        public GetGalleryCategoryByIdQueryHandler(IMapper mapper,
            IGalleryCategoryRepository repo,
            IAppLogger<GetGalleryCategoryByIdQueryHandler> logger)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._logger = logger;
        }

        public async Task<GalleryCategoryDTO> Handle(GetGalleryCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetByIdAsync(request.id);

            var data = _mapper.Map<GalleryCategoryDTO>(item);

            _logger.LogInformation("Galleries retrieved successfully.");
            return data;
        }
    }
}
