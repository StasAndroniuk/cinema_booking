using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Movies.Dtos;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Tests.ModelTests
{
    internal class MovieTests : BaseTest
    {
        [Test]
        public void Constructor_UserCorrectArgs_MovieCreated()
        {
            var name = "name";
            var description = "description";
            var duration = (ushort)33;
            var genre = MovieGenre.Drama;

            var movie = new Movie(name, description, duration, genre);

            movie.Should().NotBeNull();
            movie.Name.Should().Be(name);
            movie.Description.Should().Be(description);
            movie.Duration.Should().Be(duration);
            movie.Genre.Should().Be(genre);
        }

        [Test]
        public void UpdateMovie_UseCorrectArgs_MovieUpdated()
        {
            var name = "name";
            var description = "description";
            var duration = (ushort)33;
            var genre = MovieGenre.Drama;

            var movie = new Movie(name, description, duration, genre);
            name = "new name";
            description = "new desc";
            genre = MovieGenre.Action;
            duration = (ushort)11;
            movie.UpdateMovie(new MovieUpdateDetails { Name = name, Description = description, Genre = genre, Duration = duration });

            movie.Name.Should().Be(name);
            movie.Description.Should().Be(description);
            movie.Duration.Should().Be(duration);
            movie.Genre.Should().Be(genre);
        }
    }
}
