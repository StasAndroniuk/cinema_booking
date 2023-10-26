using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Contract.Api.Requests
{
    public class DeleteMovieRequest
    {
        /// <summary>
        /// Movie Id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
