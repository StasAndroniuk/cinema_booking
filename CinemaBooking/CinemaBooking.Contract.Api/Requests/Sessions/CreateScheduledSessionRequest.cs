using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Contract.Api.Requests.Sessions
{
    public class CreateScheduledSessionRequest
    {
        /// <summary>
        /// Id of the movie.
        /// </summary>
        [Required]
        public Guid MovieId { get; set; }

        /// <summary>
        /// Theater id
        /// </summary>
        [Required]
        public Guid TheaterId { get; set; }

        /// <summary>
        /// Session start date
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Session end date
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Session price
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
