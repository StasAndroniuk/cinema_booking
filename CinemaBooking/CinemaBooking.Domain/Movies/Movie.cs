using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Movies
{
    public class Movie
    {
        public Movie(string name, string description, ushort duration, MovieGenre genre)
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ushort Duration { get; set; }

        public MovieGenre Genre { get; set; }
    }
}
