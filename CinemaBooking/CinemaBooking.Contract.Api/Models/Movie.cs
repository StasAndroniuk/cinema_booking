namespace CinemaBooking.Contract.Api.Models
{
    /// <summary>
    /// Enity that represients movie.
    /// </summary>
    public class Movie
    { 
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
        public string Genre { get; private set; }
    }
}
