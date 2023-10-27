using CinemaBooking.Domain.Movies;

namespace CinemaBooking.Domain.Sessions
{
    public class AvailableSession
    {
        public Guid SessionId { get; set; }
        public Movie Movie { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public IEnumerable<AvailableSit> AvailableSits { get; set; }

    }
}
