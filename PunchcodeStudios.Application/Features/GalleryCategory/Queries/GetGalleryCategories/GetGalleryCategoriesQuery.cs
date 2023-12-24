using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Queries.GetGalleryCategories
{
    public record GetGalleryCategoriesQuery : IRequest<List<GalleryCategoryDTO>>;
}
