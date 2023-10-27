using CinemaBooking.Contract.Api.Models;

namespace CinemaBooking.Contract.Api.Responses
{
    public class GetReservationDetailsResponse
    {
        public MovieTicket Ticket { get; set; }
    }
}
