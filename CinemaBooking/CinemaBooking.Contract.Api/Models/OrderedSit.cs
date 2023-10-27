namespace CinemaBooking.Contract.Api.Models
{
    public class OrderedSit
    {
        public Guid Id { get; set; }

        public ushort RowNumber { get; set; }

        public ushort SitNumber { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public bool IsReserved { get; set; }
        public DateTime ReservedTill { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
