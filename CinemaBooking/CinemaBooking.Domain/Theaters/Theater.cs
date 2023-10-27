using CinemaBooking.Domain.Theaters.Dtos;

namespace CinemaBooking.Domain.Theaters
{
    /// <summary>
    /// Entity that represents room to show movie
    /// </summary>
    public class Theater
    {
        private Theater() { }
        public Theater(ushort rows, ushort sitsInRow) 
        {
            Id = Guid.NewGuid();
            RowCount = rows;
            SitsInRow = sitsInRow;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// Number of sits rows
        /// </summary>
        public ushort RowCount { get; private set; }

        /// <summary>
        /// Number of sits in 1 row
        /// </summary>
        public ushort SitsInRow { get; private set; }

        public void Update(TheaterUpdateDetails details)
        {
            RowCount = details.RowCount;
            SitsInRow = details.SitsInRow;
        }
    }
}
