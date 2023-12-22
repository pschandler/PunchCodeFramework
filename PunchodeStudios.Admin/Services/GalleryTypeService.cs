using Blazored.LocalStorage;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Services
{
    public class GalleryTypeService : BaseHttpService, IGalleryTypeService
    {
        public GalleryTypeService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}
