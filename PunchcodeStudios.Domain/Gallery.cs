using PunchcodeStudios.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Domain;

public class Gallery : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid GalleryTypeId { get; set; }

    public List<CategoryGallery> CategoryGalleries { get; set; } = new();
    public List<Category> Categories { get; } = new();
    public GalleryType Type { get; set; } = new();
}
