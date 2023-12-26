using System;
using PunchcodeStudios.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Features.Category
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Galleries = new List<Domain.Gallery>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IReadOnlyList<Domain.Gallery> Galleries { get; set; }
        public IList<Domain.CategoryGallery> CategoryGalleries { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
