using CinemaBooking.Domain.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Movies
{
    /// <summary>
    /// Enity that represients movie.
    /// </summary>
    public class Movie
    {
        private Movie() { }
        public Movie(string name, string description, ushort duration, MovieGenre genre)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Duration = duration;
            Genre = genre;
        }

        /// <summary>
        /// Unique identifier of movie.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Movie name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Movie description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Movie diration in minutes.
        /// </summary>
        public ushort Duration { get; private set; }

        /// <summary>
        /// Movie genre.
        /// </summary>
        public MovieGenre Genre { get; private set; }

        public void UpdateMovie(MovieUpdateDetails movieUpdateDetails)
        {
            Name = movieUpdateDetails.Name;
            Description = movieUpdateDetails.Description;
            Duration = movieUpdateDetails.Duration;
            Genre = movieUpdateDetails.Genre;
        }
    }
}
