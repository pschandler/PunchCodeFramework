using Microsoft.EntityFrameworkCore;
using PunchcodeStudios.Domain;
using PunchcodeStudios.Persistence.DatabaseContext;
using Shouldly;

namespace PunchcodeStudios.Persistence.IntegrationTests
{
    public class PCStudioDbContextTests
    {
        private PCStudioDbContext _pcDatabaseContext;

        public PCStudioDbContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<PCStudioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _pcDatabaseContext = new PCStudioDbContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreated()
        {
            //Arrange
            var gallery = new Gallery
            {
                Name = "Mock Gallery One",
                Description = "Mock Gallery One Description",
            };

            //Act
            await _pcDatabaseContext.Galleries.AddAsync(gallery);
            await _pcDatabaseContext.SaveChangesAsync();

            // Assert
            gallery.DateCreated.ShouldNotBeNull();
            gallery.DateCreated.ShouldNotBeSameAs(DateTime.MinValue);
        }

        [Fact]
        public async void Save_SetDateUpdated()
        {
            //Arrange
            var gallery = new Gallery
            {
                Id = new Guid("90ad90d6-b511-4025-8720-8c806702f4b2"),
                Name = "Mock Gallery One",
                Description = "Mock Gallery One Description",
            };

            //Act
            await _pcDatabaseContext.Galleries.AddAsync(gallery);
            await _pcDatabaseContext.SaveChangesAsync();

            // Assert
            gallery.DateUpdated.ShouldNotBeNull();
            gallery.DateUpdated.ShouldNotBeSameAs(DateTime.MinValue);
        }

        [Fact]
        public void Delete_SetDateDeleted()
        {

        }
    }
}