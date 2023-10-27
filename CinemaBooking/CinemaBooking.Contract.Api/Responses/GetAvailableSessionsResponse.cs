using CinemaBooking.Contract.Api.Models;

namespace CinemaBooking.Contract.Api.Responses
{
    public class GetAvailableSessionsResponse
    {
        public IEnumerable<AvailableSession> AvailableSessions { get; set; }
    }
}
