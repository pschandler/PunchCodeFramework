namespace PunchcodeStudios.Admin.Models.Gallery
{
    public class GalleryViewModel
    {
        public GalleryViewModel()
        {
            Categories = new List<GalleryCategoryViewModel>();
            Types = new List<GalleryTypeViewModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set;}

        public List<GalleryCategoryViewModel> Categories { get; set; }
        public List<GalleryTypeViewModel> Types { get; set; }

    }
}
