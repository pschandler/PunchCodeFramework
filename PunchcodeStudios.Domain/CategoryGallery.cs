using PunchcodeStudios.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Domain
{
    public class CategoryGallery : BaseEntity
    {
        public Guid GalleriesId { get; set; } 
        public Guid CategoriesId { get; set; }

        public Gallery Gallery { get; set; }
        public Category Category { get; set; }
    }
}
