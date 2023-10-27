using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Theaters;

namespace CinemaBooking.Domain.Sessions
{
    public class ScheduledSession
    {
        private ScheduledSession() { }
        public ScheduledSession(DateTime startDate, DateTime endDate, Movie movie, Theater theater)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
            EndDate = endDate;
            Movie = movie;
            Theater = theater;
        }

        public Guid Id { get; private set; }
        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public Movie Movie { get; private set; }

        public Theater Theater { get; private set; }

        public IList<OrderedSit> OrderedSits { get; private set; }
    }
}
