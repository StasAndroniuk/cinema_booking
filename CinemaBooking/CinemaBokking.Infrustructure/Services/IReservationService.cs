using CinemaBooking.Domain.Sessions;
using CinemaBooking.Domain.Sessions.Dtos;

namespace CinemaBooking.Infrustructure.Services
{
    public interface IReservationService
    {
        /// <summary>
        /// Retreaves avalible sessions for specific movie.
        /// </summary>
        /// <param name="movieId">Id of movie</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IEnumerable<AvailableSession>> GetAvailableSessionsAsync(Guid movieId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Make a reservation of the sit.
        /// </summary>
        /// <param name="reservationDetails"><see cref="ReservationDetails"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<Guid> ReserveSitInSessionAsync(ReservationDetails reservationDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Confirms reserved sit
        /// </summary>
        /// <param name="sessionId">Session id</param>
        /// <param name="reservedSitId">Reserved sit id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task ConfirmResevationAsync(Guid sessionId, Guid reservedSitId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get details of reserved sit
        /// </summary>
        /// <param name="sessionId">Id of movie session</param>
        /// <param name="reservationId">Id of reserved sit</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Details of reseved movie ticket</returns>
        Task<MovieTicket> GetReservationDetailsAsync(Guid sessionId, Guid reservationId, CancellationToken cancellationToken = default);

    }
}
