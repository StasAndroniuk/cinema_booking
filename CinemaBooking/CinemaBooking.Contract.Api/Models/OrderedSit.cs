namespace CinemaBooking.Contract.Api.Models
{
    public class OrderedSit
    {
        public Guid Id { get; private set; }

        public ushort RowNumber { get; private set; }

        public ushort SitNumber { get; private set; }

        public bool IsReserved { get; private set; }

        public bool IsConfirmed { get; private set; }
    }
}
