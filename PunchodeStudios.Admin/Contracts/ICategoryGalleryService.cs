namespace PunchcodeStudios.Admin.Contracts
{
    public interface ICategoryGalleryService
    {
        void AddGalleryToCategory(Guid galleryId, Guid CategoryId);
    }
}
