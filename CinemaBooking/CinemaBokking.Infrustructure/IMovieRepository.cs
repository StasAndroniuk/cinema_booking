﻿using CinemaBooking.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Infrustructure
{
    /// <summary>
    /// Api used for movie managment.
    /// </summary>
    public interface IMovieRepository
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
        /// <param name="movie"><see cref="Movie"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates existing movie.
        /// </summary>
        /// <param name="movie"><see cref="Movie"/>.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task UpdateMovie(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes specific movie by id.
        /// </summary>
        /// <param name="movie">instance of movie to remove.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteMovie(Movie movie, CancellationToken cancellationToken);

    }
}
