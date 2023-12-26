using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category.Queries.GetCategoriesByName
{
    public record GetCategoryByNameQuery(string name) : IRequest<CategoryDTO>;
}
