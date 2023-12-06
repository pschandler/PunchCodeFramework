using System;
using MediatR;


namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleriesByTypeName;

public record GetGalleriesByTypeNameQuery(string TypeName) : IRequest<List<GalleryDTO>>;