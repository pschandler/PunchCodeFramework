using System;
using MediatR;

namespace PunchcodeStudios.Application.Features.Gallery.Queries.GetGalleryById;

public record GetGalleryByIdQuery(Guid Id) : IRequest<GalleryDTO>;
