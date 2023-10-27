using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Theaters.Dtos;
using CinemaBooking.Infrustructure.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Tests.ApplicationTests
{
    internal class TheaterServiceTests : BaseTest
    {
        [Test]
        public async Task CreateTheaterAsync_UseCorrectArgs_TheaterCreated()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22};

            var thaterId = await theaterService.CreateTheaterAsync(creationDetails);

            var theater = await theaterService.GetTheaterAsync(thaterId);

            theater.Should().NotBeNull();
        }

        [Test]
        public async Task GetTheaterAsync_UseCorrectArgs_TheaterRecieved()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var thaterId = await theaterService.CreateTheaterAsync(creationDetails);

            var theater = await theaterService.GetTheaterAsync(thaterId);

            theater.Should().NotBeNull();
        }

        [Test]
        public async Task GetTheaterAsync_UseNotExistingId_ReturnsNull()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var id = Guid.NewGuid();

            var theater = await theaterService.GetTheaterAsync(id);
            theater.Should().BeNull();
        }

        [Test]
        public async Task UpdateTheaterAsync_UseCorrectArgs_TheaterUpdated()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var thaterId = await theaterService.CreateTheaterAsync(creationDetails);

            var updateDetails = new TheaterUpdateDetails { RowCount = 22, SitsInRow = 44 };
            await theaterService.UpdateTheaterAsync(thaterId, updateDetails);
            
            var theater = await theaterService.GetTheaterAsync(thaterId);
            theater.Should().NotBeNull();
            theater.SitsInRow.Should().Be(updateDetails.SitsInRow);
            theater.RowCount.Should().Be(updateDetails.RowCount);
        }

        [Test]
        public async Task UpdateTheaterAsync_UseNotExtsingTheater_ThrowsEntitynotFoundException()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var theaterId = Guid.NewGuid();
            var updateDetails = new TheaterUpdateDetails { RowCount = 22, SitsInRow = 44 };

            var action = async () => await theaterService.UpdateTheaterAsync(theaterId, updateDetails);

            await action.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Test]
        public async Task DeleteTheaterAsync_UseNotExtsingTheater_ThrowsEntitynotFoundException()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var theaterId = Guid.NewGuid();

            var action = async () => await theaterService.DeleteTheaterAsync(theaterId);

            await action.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Test]
        public async Task DeleteTheaterAsync_UseCorrectArhgs_TheaterDeleted()
        {
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;
            var creationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(creationDetails);

            await theaterService.DeleteTheaterAsync(theaterId);

            var theater = await theaterService.GetTheaterAsync(theaterId);

            theater.Should().BeNull();
        }
    }
}
