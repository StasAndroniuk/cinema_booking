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
    }
}
