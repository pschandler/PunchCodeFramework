using PunchcodeStudios.Domain.Common;

namespace PunchcodeStudios.Domain;

public class GalleryCategory : BaseEntity
{
    public GalleryCategory()
    {
        Galleries = new List<Gallery>();
    }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Gallery> Galleries { get; set; }

}
