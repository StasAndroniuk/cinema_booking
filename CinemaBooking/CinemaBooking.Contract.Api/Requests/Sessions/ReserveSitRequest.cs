using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Contract.Api.Requests.Sessions
{
    public class ReserveSitRequest
    {
        /// <summary>
        /// Id scheduled movie session
        /// </summary>
        [Required]
        public Guid SessionId { get; set; }

        /// <summary>
        /// Row number
        /// </summary>
        [Required]
        [Range(1, ushort.MaxValue)]
        public ushort RowNumber { get; set; }

        /// <summary>
        /// Sit number
        /// </summary>
        [Required]
        [Range(1, ushort.MaxValue)]
        public ushort SitNumber { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        [Required]
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer phone number
        /// </summary>
        [Required]
        public string CustomerPhoneNumber { get; set; }
    }
}
