using CinemaBooking.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Infrustructure.Repositories
{
    /// <summary>
    /// API manages movie sessions
    /// </summary>
    public interface IScheduledSessionRepository
    {
        /// <summary>
        /// Retreaves schedulled session by theater id
        /// </summary>
        /// <param name="theaterId">theater Id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<ScheduledSession?> TryGetScheduledSessionAsync(Guid theaterId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create enw schedulled session.
        /// </summary>
        /// <param name="session"><see cref="ScheduledSession"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task CreateSessionAsync(ScheduledSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Trys find existing session for specific date and specific movie
        /// </summary>
        /// <param name="movieId">Id of the movie</param>
        /// <param name="theaterId">Id of theater</param>
        /// <param name="startDate">Session start date</param>
        /// <param name="endDate">Session end date</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<ScheduledSession?> TryFindSchedulledSessionAsync(Guid movieId, Guid theaterId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);


        /// <summary>
        /// Returns schedulled session if it exists.
        /// </summary>
        /// <param name="sessionId">Schedulled session id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<ScheduledSession?> GetScheduledSessionAsync(Guid sessionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes schedulled session.
        /// </summary>
        /// <param name="session">Schedulled session</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task DeleteSchedulledSession(ScheduledSession session, CancellationToken cancellationToken = default);
    }
}
