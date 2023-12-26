using AutoMapper;
using PunchcodeStudios.Application.Features.CategoryGallery;
using PunchcodeStudios.Application.Features.CategoryGallery.Commands.AddCategoryGallery;
using PunchcodeStudios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.MappingProfiles
{
    public class CategoryGalleryProfile : Profile
    {
        public CategoryGalleryProfile()
        {
            CreateMap<CategoryGalleryDTO, CategoryGallery>().ReverseMap();
            CreateMap<AddGalleryToCategoryCommand, CategoryGallery>()
                .ReverseMap();
        }
    }
}
