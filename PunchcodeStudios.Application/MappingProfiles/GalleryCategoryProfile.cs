using System;
using AutoMapper;
using PunchcodeStudios.Application.Features.GalleryCategory;
using PunchcodeStudios.Application.Features.GalleryCategory.Commands.CreateGalleryCategory;
using PunchcodeStudios.Application.Features.GalleryCategory.Commands.UpdateGalleryCategory;
using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.MappingProfiles
{
    public class GalleryCategoryProfile : Profile
    {
        public GalleryCategoryProfile()
        {
            CreateMap<GalleryCategoryDTO, GalleryCategory>().ReverseMap();

            CreateMap<CreateGalleryCategoryCommand, GalleryCategory>();
            CreateMap<UpdateGalleryCategoryCommand, GalleryCategory>();
        }
    }
}
