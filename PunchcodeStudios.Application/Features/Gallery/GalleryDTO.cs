using System;
using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Features.Gallery
{
    public class GalleryDTO
    {
        public GalleryDTO()
        {
            GalleryCategories = new List<GalleryCategory>();
            GalleryTypes = new List<GalleryType>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IReadOnlyList<GalleryCategory> GalleryCategories { get; set; }
        public IReadOnlyList<GalleryType> GalleryTypes { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
