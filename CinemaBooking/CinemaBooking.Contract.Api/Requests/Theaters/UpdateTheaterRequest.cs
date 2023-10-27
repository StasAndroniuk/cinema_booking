using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Contract.Api.Requests.Theaters
{
    public class UpdateTheaterRequest
    {
        /// <summary>
        /// Number of sits rows
        /// </summary>
        [Required]
        [Range(1, ushort.MaxValue)]
        public ushort RowCount { get; set; }

        /// <summary>
        /// Number of sits in 1 row
        /// </summary>
        [Required]
        [Range(1, ushort.MaxValue)]
        public ushort SitsInRow { get; set; }
    }
}
