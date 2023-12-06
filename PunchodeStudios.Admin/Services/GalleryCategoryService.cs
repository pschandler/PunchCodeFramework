using PunchodeStudios.Admin.Contracts;
using PunchodeStudios.Admin.Services.Base;

namespace PunchodeStudios.Admin.Services
{
    public class GalleryCategoryService : BaseHttpService, IGalleryCategoryService
    {
        public GalleryCategoryService(IClient client) : base(client)
        {

        }
    }
}
