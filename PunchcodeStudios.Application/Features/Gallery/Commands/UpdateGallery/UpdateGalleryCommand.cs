using MediatR;
using PunchcodeStudios.Application.Features.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Gallery.Commands.UpdateGallery
{
    public class UpdateGalleryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid GalleryTypeId { get; set; }

        public DateTime DateCreated { get; set; }
        public List<CategoryDTO>? Categories { get; set; }
    }
}
