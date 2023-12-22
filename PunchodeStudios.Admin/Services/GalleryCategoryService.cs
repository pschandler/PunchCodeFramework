using Blazored.LocalStorage;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Services
{
    public class GalleryCategoryService : BaseHttpService, IGalleryCategoryService
    {
        public GalleryCategoryService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}
