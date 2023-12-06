using PunchodeStudios.Admin.Contracts;
using PunchodeStudios.Admin.Services.Base;

namespace PunchodeStudios.Admin.Services
{
    public class GalleryTypeService : BaseHttpService, IGalleryTypeService
    {
        public GalleryTypeService(IClient client) : base(client)
        {

        }
    }
}
