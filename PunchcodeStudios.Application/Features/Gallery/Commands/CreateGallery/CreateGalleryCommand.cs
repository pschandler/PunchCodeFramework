using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery
{
    public class CreateGalleryCommand : IRequest<Guid>
    {
       public string Name { get; set; } = string.Empty;
       public string Description { get; set; } = string.Empty;
    }
}
