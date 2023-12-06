using System;
using MediatR;

namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleries;

public record GetGalleriesQuery : IRequest<List<GalleryDTO>>;
