using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Infrustructure.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// Method used to get specific movie by id.
        /// </summary>
        /// <param name="id">Id of requested movie</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Instance of requested movie.</returns>
        Task<Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available movies.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Return colllection of movies</returns>
        Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Create new instance of movie.
        /// </summary>
        /// <param name="movieCreationDetails"><see cref="MovieCreationDetails"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task<Guid> CreateMovieAsync(MovieCreationDetails movieCreationDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates existing movie.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <param name="movieUpdateDetails"><see cref="MovieUpdateDetails"/>.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task UpdateMovieAsync(Guid id, MovieUpdateDetails movieUpdateDetails, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes specific movie by id.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteMovieAsync(Guid movieId, CancellationToken cancellationToken = default);

    }
}
