namespace CinemaBooking.Contract.Api.Models
{
    public class Theater
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Number of sits rows
        /// </summary>
        public ushort RowCount { get; set; }

        /// <summary>
        /// Number of sits in 1 row
        /// </summary>
        public ushort SitsInRow { get; set; }
    }
}
