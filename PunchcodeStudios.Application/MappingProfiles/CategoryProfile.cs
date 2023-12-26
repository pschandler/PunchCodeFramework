using System;
using AutoMapper;
using PunchcodeStudios.Application.Features.Category;
using PunchcodeStudios.Application.Features.Category.Commands.CreateCategory;
using PunchcodeStudios.Application.Features.Category.Commands.UpdateCategory;
using PunchcodeStudios.Domain;

namespace PunchcodeStudios.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
