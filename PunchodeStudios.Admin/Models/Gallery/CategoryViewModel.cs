using System.ComponentModel.DataAnnotations;

namespace PunchcodeStudios.Admin.Models.Gallery;

public class CategoryViewModel
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string Description { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public List<GalleryViewModel> Galleries { get; set; } = new List<GalleryViewModel>();
    public List<CategoryGalleryViewModel> CategoryGalleries { get; set; }
}
