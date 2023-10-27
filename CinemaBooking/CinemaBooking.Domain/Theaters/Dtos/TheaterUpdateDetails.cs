namespace CinemaBooking.Domain.Theaters.Dtos
{
    public class TheaterUpdateDetails
    {
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
