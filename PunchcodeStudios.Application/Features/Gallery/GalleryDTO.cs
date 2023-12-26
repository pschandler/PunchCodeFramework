using System;
using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Features.Gallery
{
    public class GalleryDTO
    {
        public GalleryDTO()
        {
            Categories = new List<Domain.Category>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IReadOnlyList<Domain.Category> Categories { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid GalleryTypeId { get; set; }
    }
}
