using System;
using AutoMapper;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Application.Features.Gallery;
using PunchcodeStudios.Application.Features.Gallery.Commands.CreateGallery;
using PunchcodeStudios.Application.Features.Gallery.Commands.UpdateGallery;

namespace PunchcodeStudios.Application.MappingProfiles
{
    public class GalleryProfile : Profile
    {
        public GalleryProfile() {
            CreateMap<GalleryDTO, Gallery>().ReverseMap();

            CreateMap<CreateGalleryCommand, Gallery>();
            CreateMap<UpdateGalleryCommand, Gallery>();
        }
    }
}
