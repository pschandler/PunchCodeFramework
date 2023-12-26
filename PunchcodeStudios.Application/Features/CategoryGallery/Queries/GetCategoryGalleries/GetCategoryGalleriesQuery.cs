using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.CategoryGallery.Queries.GetCategoryGalleries
{
    public record GetCategoryGalleriesQuery : IRequest<List<CategoryGalleryDTO>>;
}
