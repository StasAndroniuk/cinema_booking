namespace CinemaBooking.Contract.Api.Requests.Sessions
{
    public class ReserveSitRequest
    {
        /// <summary>
        /// Id scheduled movie session
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Row number
        /// </summary>
        public ushort RowNumber { get; set; }

        /// <summary>
        /// Sit number
        /// </summary>
        public ushort SitNumber { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer phone number
        /// </summary>
        public string CustomerPhoneNumber { get; set; }
    }
}
