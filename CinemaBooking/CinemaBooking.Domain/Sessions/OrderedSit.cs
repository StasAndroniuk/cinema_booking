namespace CinemaBooking.Domain.Sessions
{
    public class OrderedSit
    {
        public OrderedSit(ushort rowNumber, ushort sitNumber, string customerName, string customerPhoneNumber)
        {
            Id = Guid.NewGuid();
            RowNumber = rowNumber;
            SitNumber = sitNumber;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
        }

        public Guid Id { get; private set; }

        public ushort RowNumber { get; private set; }

        public ushort SitNumber { get; private set; }

        public string CustomerName { get; private set; }

        public string CustomerPhoneNumber { get; private set; }

        public bool IsReserved { get; private set; }

        public DateTime ReservedTill { get; private set; }

        public bool IsConfirmed { get; private set; }

        public void Reserve()
        {
            IsReserved = true;
            ReservedTill = DateTime.Now.AddHours(Constants.ReservationTDurationInHours);
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}
