using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Movies.Dtos
{
    /// <summary>
    /// Entity used for movie update operation.
    /// Contains data available for update.
    /// </summary>
    public class MovieUpdateDetails
    {
        /// <summary>
        /// Movie name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Movie description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Movie diration in minutes.
        /// </summary>
        public ushort Duration { get; set; }

        /// <summary>
        /// Movie genre.
        /// </summary>
        public MovieGenre Genre { get; set; }
    }
}
