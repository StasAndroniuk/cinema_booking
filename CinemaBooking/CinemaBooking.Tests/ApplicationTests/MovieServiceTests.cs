using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Movies.Dtos;
using CinemaBooking.Infrustructure.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Tests.ApplicationTests
{
    internal class MovieServiceTests : BaseTest
    {
        [Test]
        public async Task CreateMovieAsync_UseCorrectArgs_MovieCreated()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            var id = await service.CreateMovieAsync(creationDetails);


            var createdMovie = await service.GetMovieAsync(id);
            createdMovie.Should().NotBeNull();
            createdMovie.Name.Should().Be(creationDetails.Name);
            createdMovie.Description.Should().Be(creationDetails.Description);
            createdMovie.Duration.Should().Be(creationDetails.Duration);
            createdMovie.Genre.Should().Be(creationDetails.Genre);
        }

        [Test]
        public async Task CreateMovieAsync_CreateDuplicateMovie_throwsMovieDuplicateException()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };

            await service.CreateMovieAsync(creationDetails);
            var action = async () => await service.CreateMovieAsync(creationDetails);
            await action.Should().ThrowAsync<MovieDuplicateException>();
        }

        [Test]
        public async Task GetMovieAsync_UseCorrectId_MovieRecieved()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };
            var id = await service.CreateMovieAsync(creationDetails);
            var movie = await service.GetMovieAsync(id);
            movie.Should().NotBeNull();
        }

        [Test]
        public async Task GetMovieAsync_NotExistingId_ThrowsEntityNotFoundException()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var action = async () => await service.GetMovieAsync(Guid.NewGuid());

            await action.Should().ThrowAsync<EntityNotFoundException>();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(12)]
        public async Task GetMoviesAsync_UseCorrectArgs_MoviesRecieved(int expectedMovieCount)
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            for(int i = 0; i < expectedMovieCount; i++)
            {
                var creationDetails = new MovieCreationDetails()
                {
                    Name = Guid.NewGuid().ToString(),
                    Description = "description",
                    Duration = 42,
                    Genre = Domain.Movies.MovieGenre.Action
                };
                await service.CreateMovieAsync(creationDetails);
            }

            var movies = await service.GetMoviesAsync();

            movies.Should().NotBeNull();
            movies.Count().Should().BePositive();
        }

        [Test]
        public async Task UpdateMovieAsync_UseCorrectArgs_MovieUpdated()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };
            var id = await service.CreateMovieAsync(creationDetails);

            var updateDetails = new MovieUpdateDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "new Description",
                Duration = 99,
                Genre = Domain.Movies.MovieGenre.Documentary,
            };

            await service.UpdateMovieAsync(id, updateDetails);

            var movie = await service.GetMovieAsync(id);
            movie.Should().NotBeNull();
            movie.Name.Should().Be(updateDetails.Name);
            movie.Description.Should().Be(updateDetails.Description);
            movie.Duration.Should().Be(updateDetails.Duration);
            movie.Genre.Should().Be(updateDetails.Genre);
        }

        [Test]
        public async Task UpdateMovieAsync_UseSameName_MovieUpdated()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };
            var id = await service.CreateMovieAsync(creationDetails);

            var updateDetails = new MovieUpdateDetails()
            {
                Name = creationDetails.Name,
                Description = "new Description",
                Duration = 99,
                Genre = Domain.Movies.MovieGenre.Documentary,
            };

            await service.UpdateMovieAsync(id, updateDetails);

            var movie = await service.GetMovieAsync(id);
            movie.Should().NotBeNull();
            movie.Name.Should().Be(updateDetails.Name);
            movie.Description.Should().Be(updateDetails.Description);
            movie.Duration.Should().Be(updateDetails.Duration);
            movie.Genre.Should().Be(updateDetails.Genre);
        }

        [Test]
        public async Task UpdateMovieAsync_UseExistingName_ThrowsMovieDuplicateException()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;
            var duplicateName = Guid.NewGuid().ToString();
            var creationDetails = new MovieCreationDetails()
            {
                Name = duplicateName,
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };
            await service.CreateMovieAsync(creationDetails);

            creationDetails = new MovieCreationDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };
            var id = await service.CreateMovieAsync(creationDetails);

            var updateDetails = new MovieUpdateDetails()
            {
                Name = duplicateName,
                Description = "new Description",
                Duration = 99,
                Genre = Domain.Movies.MovieGenre.Documentary,
            };

            var action = async () => await service.UpdateMovieAsync(id, updateDetails);
            await action.Should().ThrowAsync<MovieDuplicateException>();
        }

        [Test]
        public async Task UpdateMovieAsync_UsenotExistingId_ThrowsEntityNotFoundException()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;

            var id = Guid.NewGuid();

            var updateDetails = new MovieUpdateDetails()
            {
                Name = Guid.NewGuid().ToString(),
                Description = "new Description",
                Duration = 99,
                Genre = Domain.Movies.MovieGenre.Documentary,
            };

            var action = async () => await service.UpdateMovieAsync(id, updateDetails);
            await action.Should().ThrowAsync<EntityNotFoundException>();
        }

        [Test]
        public async Task DeleteMovieAsync_UseCorrectArgs_MovieDeteled()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;
            var duplicateName = Guid.NewGuid().ToString();
            var creationDetails = new MovieCreationDetails()
            {
                Name = duplicateName,
                Description = "description",
                Duration = 42,
                Genre = Domain.Movies.MovieGenre.Action
            };
            var id = await service.CreateMovieAsync(creationDetails);

            await service.DeleteMovieAsync(id);

            var movies = await service.GetMoviesAsync();

            var movie = movies.FirstOrDefault(m => m.Id == id);
            movie.Should().BeNull();

        }

        [Test]
        public async Task DeleteMovieAsync_UseNotExistingId_ThrowsEnityNotFoundException()
        {
            var service = TestServiceProvider.GetService<IMovieService>()!;
            var id = Guid.NewGuid();

            var action = async () => await service.DeleteMovieAsync(id);

            await action.Should().ThrowAsync<EntityNotFoundException>();

        }
    }
}
