namespace PunchcodeStudios.Admin.Models.Gallery;

public class GalleryTypeViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
}
