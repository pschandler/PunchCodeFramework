using System;
using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.Features.Gallery
{
    public class GalleryDTO
    {
        public GalleryDTO()
        {
            GalleryCategories = new List<Domain.GalleryCategory>();
            GalleryTypes = new List<Domain.GalleryType>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IReadOnlyList<Domain.GalleryCategory> GalleryCategories { get; set; }
        public IReadOnlyList<Domain.GalleryType> GalleryTypes { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
