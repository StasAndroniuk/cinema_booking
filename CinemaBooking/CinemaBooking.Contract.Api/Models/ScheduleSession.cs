namespace CinemaBooking.Contract.Api.Models
{
    public class ScheduleSession
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Sessions start time
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// session end time
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// selected movie to show
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// Selected theater where to show
        /// </summary>
        public Theater Theater { get; set; }

        /// <summary>
        /// Session price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ordered sits
        /// </summary>
        public IList<OrderedSit> OrderedSits { get; set; }
    }
}
