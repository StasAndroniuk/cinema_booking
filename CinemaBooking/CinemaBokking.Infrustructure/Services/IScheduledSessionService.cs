using CinemaBooking.Domain.Sessions;
using CinemaBooking.Domain.Sessions.Dtos;

namespace CinemaBooking.Infrustructure.Services
{
    public interface IScheduledSessionService
    {
        /// <summary>
        /// Creates new schedulled session
        /// </summary>
        /// <param name="sessionCreationDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Guid> CreateSchedulledSessionAssync(SessionCreationDetails sessionCreationDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns schedulled session if it exists.
        /// </summary>
        /// <param name="sessionId">Schedulled session id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<ScheduledSession?> GetScheduledSessionAsync(Guid sessionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes schedulled session if it exists.
        /// </summary>
        /// <param name="sessionId">Schedulled session id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task DeleteSessionAsync(Guid sessionId, CancellationToken cancellationToken = default);
    }
}
