using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using PunchcodeStudios.Admin.Contracts;
using PunchcodeStudios.Admin.Services.Base;

namespace PunchcodeStudios.Admin.Services
{
    public class CategoryGalleryService : BaseHttpService, ICategoryGalleryService
    {
        private readonly IMapper _mapper;
        public CategoryGalleryService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this._mapper = mapper;
        }
        public async void AddGalleryToCategory(Guid galleryId, Guid categoryId)
        {
            
            //AddGalleryToCategoryCommand command = new AddGalleryToCategoryCommand()
            //{
            //    GalleryId = galleryId,
            //    CategoryId = categoryId
            //};
            //await AddBearerToken();
            //await _client.GalleryCategoryAsync(command);
        }

    }
}
