using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Movies.Dtos;
using CinemaBooking.Domain.Sessions.Dtos;
using CinemaBooking.Domain.Theaters.Dtos;
using CinemaBooking.Infrustructure.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Tests.ApplicationTests
{
    internal class ScheduledSessionServiceTests : BaseTest
    {
        [Test]
        public async Task CreateSchedulledSessionAssync_UseCorrectArgs_SessionCreated()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var session = await service.GetScheduledSessionAsync(sessionId);
            session.Should().NotBeNull();
            session.Movie.Should().NotBeNull();
        }

        [Test]
        public async Task CreateSchedulledSessionAssync_UseNoMovie_ThrowsEntityNotFoundException()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                TheaterId = theaterId,
                Price = 22
            };

            var action = async () => await service.CreateSchedulledSessionAssync(sessionCreationDetails);
            await action.Should().ThrowAsync<EntityNotFoundException>();         
        }

        [Test]
        public async Task CreateSchedulledSessionAssync_UseNoTheater_ThrowsEntityNotFoundException()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                Price = 22
            };

            var action = async () => await service.CreateSchedulledSessionAssync(sessionCreationDetails);
            await action.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Test]
        public async Task CreateSchedulledSessionAssync_UseDuplicateSession_ThrowsSessionInvalidOperationException()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);
            var action = async () => await service.CreateSchedulledSessionAssync(sessionCreationDetails);
            await action.Should().ThrowAsync<SessionInvalidOperationException>();
        }

        [Test]
        public async Task DeleteSchedulledSessionAssync_UseRemovePending_ThrowsSessionInvalidOperationException()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(-2),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

            var action = async () => await service.DeleteSessionAsync(sessionId);

            await action.Should().ThrowAsync<SessionInvalidOperationException>();
        }

        [Test]
        public async Task DeleteSchedulledSessionAssync_UseCorrectArgs_SessionRemoved()
        {
            var service = TestServiceProvider.GetService<IScheduledSessionService>()!;
            var movieService = TestServiceProvider.GetService<IMovieService>()!;
            var theaterService = TestServiceProvider.GetService<ITheaterService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await movieService.CreateMovieAsync(creationDetails);


            var theaterCreationDetails = new TheaterCreationDetails { RowCount = 12, SitsInRow = 22 };

            var theaterId = await theaterService.CreateTheaterAsync(theaterCreationDetails);

            var sessionCreationDetails = new SessionCreationDetails
            {
                StartDate = DateTime.Now.AddHours(1),
                EndDate = DateTime.Now.AddHours(3),
                MovieId = id,
                TheaterId = theaterId,
                Price = 22
            };

            var sessionId = await service.CreateSchedulledSessionAssync(sessionCreationDetails);

             await service.DeleteSessionAsync(sessionId);

            var session = await service.GetScheduledSessionAsync(sessionId);
            session.Should().BeNull();
        }
    }
}
