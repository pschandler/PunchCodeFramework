using Moq;
using PunchcodeStudios.Application.Contracts.Persisitence;
using PunchcodeStudios.Application.Features.Gallery;
using PunchcodeStudios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.UnitTests.Mocks
{
    public class MockGalleryRepository
    {
        public static Mock<IGalleryRepository> GetMockGalleryRepository()
        {
            var galleries = new List<Gallery>
            {
                new Gallery
                {
                    Id = new Guid("90ad90d6-b511-4025-8720-8c806702f4b2"),
                    Name = "Mock Gallery One",
                    Description = "Mock Gallery One Description",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DateDeleted = null
                },
                new Gallery
                {
                    Id = new Guid("391aa0d8-05a7-4603-b5b3-49247510481b"),
                    Name = "Mock Gallery Two",
                    Description = "Mock Gallery Two Description",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DateDeleted = null
                },
                new Gallery
                {
                    Id = new Guid("385e4b9c-7a34-48f8-8dc4-0bc0bd532e23"),
                    Name = "Mock Gallery Three",
                    Description = "Mock Gallery Three Description",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DateDeleted = null
                }
            };

            var mockRepo = new Mock<IGalleryRepository>();
            mockRepo.Setup(m => m.GetAsync(false)).ReturnsAsync(galleries);
            return mockRepo;
        }
    }
}
