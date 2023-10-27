using CinemaBooking.Domain.Theaters;
using CinemaBooking.Domain.Theaters.Dtos;

namespace CinemaBooking.Infrustructure.Services
{
    public interface ITheaterService
    {
        /// <summary>
        /// Cretes new instance of theater
        /// </summary>
        /// <param name="theaterCreationDetails"><see cref="TheaterCreationDetails"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<Guid> CreateTheaterAsync(TheaterCreationDetails theaterCreationDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes theater
        /// </summary>
        /// <param name="theaterId">Id of theater</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task DeleteTheaterAsync(Guid theaterId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update theater
        /// </summary>
        /// <param name="theaterId">id of theater</param>
        /// <param name="theaterUpdateDetails"><see cref="TheaterUpdateDetails"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateTheaterAsync(Guid theaterId, TheaterUpdateDetails theaterUpdateDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns theater by id
        /// </summary>
        /// <param name="id">Theater id.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<Theater?> GetTheaterAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
