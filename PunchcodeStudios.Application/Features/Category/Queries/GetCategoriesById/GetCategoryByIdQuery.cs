using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Queries.GetCategoriesById
{
    public record GetCategoryByIdQuery(Guid id) : IRequest<CategoryDTO>;
}
