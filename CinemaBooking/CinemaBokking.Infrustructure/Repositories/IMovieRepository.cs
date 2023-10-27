using CinemaBooking.Domain.Movies;

namespace CinemaBooking.Infrustructure.Repositories
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
        Task UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes specific movie by id.
        /// </summary>
        /// <param name="movie">instance of movie to remove.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteMovieAsync(Movie movie, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns movie by name.
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<Movie> TryFindMovieByNameAsync(string name, CancellationToken cancellationToken = default);

    }
}
