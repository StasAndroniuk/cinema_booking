using CinemaBooking.Infrustructure;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using CinemaBooking.Domain.Movies;
using System.Runtime.InteropServices;
using CinemaBooking.Domain.Movies.Dtos;

namespace CinemaBooking.Tests.RepositoryTests
{
    internal class MovieRepositoryTests : BaseTest
    {
        [Test]
        public async Task CreateMovieAsync_UserCorrectArgs_MovieCreated()
        {
            var repo = TestServiceProvider.GetService<IMovieRepository>()!;
            var movie = new Movie("name", "description", 12, MovieGenre.Action);
            
            await repo.CreateMovieAsync(movie);

            var savedMovie = await repo.GetMovieAsync(movie.Id);
            savedMovie.Should().NotBeNull();
            savedMovie.Id.Should().Be(movie.Id);
            savedMovie.Name.Should().Be(movie.Name);
            savedMovie.Description.Should().Be(movie.Description);
            savedMovie.Duration.Should().Be(movie.Duration);
            savedMovie.Genre.Should().Be(movie.Genre);
        }

        [Test]
        public async Task GetMoveiAsync_UseNotExistingId_ReturnNull()
        {
            var repo = TestServiceProvider.GetService<IMovieRepository>()!;
            var Id = Guid.NewGuid();

            var movie = await repo.GetMovieAsync(Id);
            movie.Should().BeNull();
        }

        [Test]
        public async Task GetMoveiAsync_UseExistingId_ReturnMovie()
        {
            var repo = TestServiceProvider.GetService<IMovieRepository>()!;
            var movie = new Movie("name", "description", 12, MovieGenre.Action);

            await repo.CreateMovieAsync(movie);

            var recievedMovie = await repo.GetMovieAsync(movie.Id);
            recievedMovie.Should().NotBeNull();
            recievedMovie.Id.Should().Be(movie.Id);
            recievedMovie.Name.Should().Be(movie.Name);
            recievedMovie.Description.Should().Be(movie.Description);
            recievedMovie.Duration.Should().Be(movie.Duration);
            recievedMovie.Genre.Should().Be(movie.Genre);
        }

        [Test]
        public async Task GetMoviesAsync_USeCorrectArgs_ReturnsMovieList()
        {
            var repo = TestServiceProvider.GetService<IMovieRepository>()!;
            for (int i = 0; i< 5; i++)
            {
                var movie = new Movie("name", "description", 12, MovieGenre.Action);
                await repo.CreateMovieAsync(movie);
            }

            var movies = await repo.GetMoviesAsync();

            movies.Should().NotBeNull();
            movies.Count().Should().BePositive();
        }

        [Test]
        public async Task UpdateMovieAsync_UseCorrectArgs_MovieUpdated()
        {
            var repo = TestServiceProvider.GetService<IMovieRepository>()!;
            var movie = new Movie("name", "description", 12, MovieGenre.Action);
            await repo.CreateMovieAsync(movie);

            var movieToUpdate = await repo.GetMovieAsync(movie.Id);
            var updateDetails = new MovieUpdateDetails
            {
                Name = "newName",
                Description = "NewDescription",
                Duration = 44,
                Genre = MovieGenre.Drama
            };
            movieToUpdate.UpdateMovie(updateDetails);
            await repo.UpdateMovieAsync(movieToUpdate);

            movie = await repo.GetMovieAsync(movieToUpdate.Id);

            movie.Should().NotBeNull();
            movie.Name.Should().Be(movieToUpdate.Name);
            movie.Description.Should().Be(movieToUpdate.Description);
            movie.Duration.Should().Be(movieToUpdate.Duration);
            movie.Genre.Should().Be(movieToUpdate.Genre);
        }

        [Test]
        public async Task DeleteMovieAsync_UseCorrectArgs_MovieDeleted()
        {
            var repo = TestServiceProvider.GetService<IMovieRepository>()!;
            var movie = new Movie("name", "description", 12, MovieGenre.Action);

            await repo.CreateMovieAsync(movie);

            await repo.DeleteMovieAsync(movie);

            movie = await repo.GetMovieAsync(movie.Id);

            movie.Should().BeNull();
        }
    }
}
