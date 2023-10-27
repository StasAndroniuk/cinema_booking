using AutoMapper;
using CinemaBooking.Contract.Api.Models;
using CinemaBooking.Contract.Api.Requests.Sessions;
using CinemaBooking.Contract.Api.Responses;
using CinemaBooking.Domain.Sessions.Dtos;
using CinemaBooking.Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Api.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(
            IReservationService reservationService,
            IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns available sessions for specific movie
        /// </summary>
        /// <param name="MovieId">Movie id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="GetAvailableSessionsResponse"/></returns>
        [HttpGet("available-sessions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<GetAvailableSessionsResponse> GetAvailableSessions(
            [FromQuery] Guid MovieId,
            CancellationToken cancellationToken = default) =>
            new GetAvailableSessionsResponse
            {
                AvailableSessions = (await _reservationService.GetAvailableSessionsAsync(MovieId, cancellationToken))
                                    .Select(s => _mapper.Map<AvailableSession>(s))
            };

        /// <summary>
        /// Reserve spefic sit.
        /// </summary>
        /// <param name="request"><see cref="ReserveSitRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="ReserveSitResponse"/></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ReserveSitResponse> ReserveSit(
            [FromBody] ReserveSitRequest request,
            CancellationToken cancellationToken = default) =>
            new ReserveSitResponse
            {
                OrderedSitId = await _reservationService.ReserveSitInSessionAsync(_mapper.Map<ReservationDetails>(request), cancellationToken)
            };

        /// <summary>
        /// Confirms sit reservation
        /// </summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="reservedSitId">id of reserved sit</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task ConfirmReservedSit([FromQuery]Guid sessionId, [FromQuery]Guid reservedSitId, CancellationToken cancellationToken = default) =>
            await _reservationService.ConfirmResevationAsync(sessionId, reservedSitId, cancellationToken);

        /// <summary>
        /// Returns details 
        /// </summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="reservedSitId">id of reserved sit</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="GetReservationDetailsResponse"/></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<GetReservationDetailsResponse> GetReservationDetails(
            [FromQuery] Guid sessionId,
            [FromQuery] Guid reservedSitId,
            CancellationToken cancellationToken = default) =>
            new GetReservationDetailsResponse
            {
                Ticket = _mapper.Map<MovieTicket>(await _reservationService.GetReservationDetailsAsync(sessionId, reservedSitId, cancellationToken))
            };

    }
}
