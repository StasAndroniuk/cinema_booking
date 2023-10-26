using CinemaBooking.Contract.Api.Models;

namespace CinemaBooking.Contract.Api.Responses
{
    public class GetMultipleMoviesResponse
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
