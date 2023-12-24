using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.GalleryCategory.Commands.DeleteGalleryCategory
{
    public class DeleteGalleryCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
