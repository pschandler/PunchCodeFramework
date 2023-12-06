using System;
using MediatR;

namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleryByName;

public record GetGalleryByNameQuery(string Name) : IRequest<GalleryDTO>;
