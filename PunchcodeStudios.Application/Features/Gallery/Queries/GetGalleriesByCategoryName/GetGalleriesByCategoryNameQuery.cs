using System;
using MediatR;


namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleriesByCategoryName;

public record GetGalleriesByCategoryNameQuery(string CategoryName) : IRequest<List<GalleryDTO>>;
