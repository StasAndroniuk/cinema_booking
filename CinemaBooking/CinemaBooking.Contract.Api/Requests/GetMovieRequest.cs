using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Contract.Api.Requests
{
    public class GetMovieRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
