namespace CinemaBooking.Contract.Api.Models
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
