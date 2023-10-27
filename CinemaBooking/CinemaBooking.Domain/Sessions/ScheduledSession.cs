using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Theaters;

namespace CinemaBooking.Domain.Sessions
{
    /// <summary>
    /// Entity repesents one show of the movie.
    /// </summary>
    public class ScheduledSession
    {
        private ScheduledSession() { }
        public ScheduledSession(DateTime startDate, DateTime endDate, Movie movie, Theater theater, decimal price)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
            EndDate = endDate;
            Movie = movie;
            Theater = theater;
            Price = price;
        }

        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Sessions start time
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// session end time
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// selected movie to show
        /// </summary>
        public Movie Movie { get; private set; }

        public Guid MovieId { get; set; }

        /// <summary>
        /// Selected theater where to show
        /// </summary>
        public Theater Theater { get; private set; }

        public Guid TheaterId { get; set; }

        /// <summary>
        /// Session price
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Ordered sits
        /// </summary>
        public IList<OrderedSit> OrderedSits { get; private set; }
    }
}
