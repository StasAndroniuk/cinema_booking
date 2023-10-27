using CinemaBooking.Domain.Theaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Infrustructure.Repositories
{
    /// <summary>
    /// Api used to manage theaters
    /// </summary>
    public interface ITheaterRepository
    {
        /// <summary>
        /// Cretes new instance of theater
        /// </summary>
        /// <param name="theater"><see cref="Theater"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task CreateTheaterAsync(Theater theater, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes theater
        /// </summary>
        /// <param name="theater"><see cref="Theater"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task DeleteTheaterAsync(Theater theater, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update theater
        /// </summary>
        /// <param name="theater"><see cref="Theater"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateTheaterAsync(Theater theater, CancellationToken cancellationToken = default);

        /// <summary>
        /// Return theater by id
        /// </summary>
        /// <param name="theaterId">Thetaer id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Theater"/></returns>
        Task<Theater?> GetTheaterAsync(Guid theaterId, CancellationToken cancellationToken = default);
    }
}
