using CinemaBooking.Domain.Movies;

namespace CinemaBooking.Domain.Sessions
{
    public class MovieTicket
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Movie Movie { get; set; }
        public ushort RowNumber { get; set; }
        public ushort SitNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalCost { get; set; }
    }
}
