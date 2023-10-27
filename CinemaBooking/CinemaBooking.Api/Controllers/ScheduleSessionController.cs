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
    [Route("schedule-sessions")]
    public class ScheduleSessionController : ControllerBase
    {
        private readonly IScheduledSessionService _scheduledSessionService;
        private readonly IMapper _mapper;

        public ScheduleSessionController(
            IScheduledSessionService scheduledSessionService,
            IMapper mapper) 
        {
            _scheduledSessionService = scheduledSessionService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns session by id if it exists.
        /// </summary>
        /// <param name="Id">Id of the session</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="GetScheduleSessionResponse"/></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetScheduleSessionResponse> GetSchedulledSession(
            [FromRoute] Guid Id, CancellationToken cancellationToken = default) =>
            new GetScheduleSessionResponse
            {
                ScheduledSession = _mapper.Map<ScheduleSession>(await _scheduledSessionService.GetScheduledSessionAsync(Id, cancellationToken)),
            };

        /// <summary>
        /// Create new session
        /// </summary>
        /// <param name="request"><see cref="CreateScheduledSessionRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="CreateScheduledSessionResponse"/></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CreateScheduledSessionResponse> CreateScheduledSession(
            [FromBody] CreateScheduledSessionRequest request,
            CancellationToken cancellationToken = default) =>
            new CreateScheduledSessionResponse
            {
                SessionId = await _scheduledSessionService.CreateSchedulledSessionAssync(_mapper.Map<SessionCreationDetails>(request), cancellationToken),
            };

        /// <summary>
        /// Removed session.
        /// </summary>
        /// <param name="Id">Session id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteSchedulledSession([FromRoute]Guid Id, CancellationToken cancellationToken = default) =>
            await _scheduledSessionService.DeleteSessionAsync(Id, cancellationToken);
    }
}
