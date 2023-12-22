using PunchcodeStudios.Admin.Models.Gallery;
using PunchcodeStudios.Admin.Services.Base;
using AutoMapper;

namespace PunchcodeStudios.Admin.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<GalleryDTO, GalleryViewModel>()
                .ForMember(
                 dest => dest.DateCreated,
                 options => options.MapFrom(source => source.DateCreated.DateTime)
                )
                .ReverseMap();
            CreateMap<CreateGalleryCommand, GalleryViewModel>()
                .ReverseMap();
            CreateMap<UpdateGalleryCommand, GalleryViewModel>()
               .ForMember(
                 dest => dest.DateCreated,
                 options => options.MapFrom(source => source.DateCreated.DateTime)
                )
                .ReverseMap();
        }
    }
}
