using PunchcodeStudios.Domain.Common;

namespace PunchcodeStudios.Domain;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<CategoryGallery> CategoryGalleries { get; set; } = new();

    public List<Gallery> Galleries { get; } = new();
}
