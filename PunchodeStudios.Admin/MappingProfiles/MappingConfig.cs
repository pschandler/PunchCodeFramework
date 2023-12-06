using PunchodeStudios.Admin.Models.Gallery;
using PunchodeStudios.Admin.Services.Base;
using AutoMapper;

namespace PunchodeStudios.Admin.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<GalleryDTO, GalleryViewModel>().ReverseMap();
            CreateMap<CreateGalleryCommand, GalleryViewModel>().ReverseMap();
            CreateMap<UpdateGalleryCommand, GalleryViewModel>().ReverseMap();
        }
    }
}
