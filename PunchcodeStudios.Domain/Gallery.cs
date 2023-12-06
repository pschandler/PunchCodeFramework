using PunchcodeStudios.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Domain;

public class Gallery : BaseEntity
{
    public Gallery()
    {
        Categories = new List<GalleryCategory>();
        Types = new List<GalleryType>();
    }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<GalleryCategory> Categories { get; set; }
    public List<GalleryType> Types { get; set; }
}
