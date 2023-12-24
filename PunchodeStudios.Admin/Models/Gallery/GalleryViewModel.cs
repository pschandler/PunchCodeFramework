using PunchcodeStudios.UI.Components.Models;
using System.ComponentModel.DataAnnotations;

namespace PunchcodeStudios.Admin.Models.Gallery
{
    public class GalleryViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Description { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set;}

        public List<GalleryCategoryViewModel> Categories { get; set; } = new List<GalleryCategoryViewModel>();
        public List<GalleryTypeViewModel> Types { get; set; } = new List<GalleryTypeViewModel>();
        public List<SelectOption> AvailableCategories { get; set; } = new List<SelectOption>();
    }
}
