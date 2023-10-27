using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Movies;
using CinemaBooking.Domain.Movies.Dtos;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Infrustructure.Services;


namespace CinemaBooking.Application.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(
            IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }

        public async Task<Guid> CreateMovieAsync(MovieCreationDetails movieCreationDetails, CancellationToken cancellationToken = default)
        {
            var existingMovie = await _movieRepository.TryFindMovieByNameAsync(movieCreationDetails.Name, cancellationToken);
            if (existingMovie != null)
            {
                throw new MovieDuplicateException($"Movie with name {movieCreationDetails.Name} already exists.");
            }

            var movie = new Movie(
                movieCreationDetails.Name,
                movieCreationDetails.Description,
                movieCreationDetails.Duration,
                movieCreationDetails.Genre);

            await _movieRepository.CreateMovieAsync(movie, cancellationToken);
            return movie.Id;
        }

        public async Task DeleteMovieAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var movie = await _movieRepository.GetMovieAsync(movieId, cancellationToken);

            if (movie == null)
            {
                throw new EntityNotFoundException($"Movie with ID {movieId} not found");
            }

            await _movieRepository.DeleteMovieAsync(movie, cancellationToken);
        }

        public async Task<Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = await _movieRepository.GetMovieAsync(id, cancellationToken);

            if (movie == null)
            {
                throw new EntityNotFoundException($"Movie with ID {id} not found");
            }

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default) =>
            await _movieRepository.GetMoviesAsync(cancellationToken);


        public async Task UpdateMovieAsync(Guid id, MovieUpdateDetails movieUpdateDetails, CancellationToken cancellationToken = default)
        {
            var existingMovie = await _movieRepository.TryFindMovieByNameAsync(movieUpdateDetails.Name, cancellationToken);
            if (existingMovie != null && existingMovie.Id != id)
            {
                throw new MovieDuplicateException($"Movie with name {movieUpdateDetails.Name} already exists.");
            }

            var movie = await _movieRepository.GetMovieAsync(id, cancellationToken);
            if (movie == null)
            {
                throw new EntityNotFoundException($"Movie with ID {id} not found");
            }

            movie.UpdateMovie(movieUpdateDetails);

            await _movieRepository.UpdateMovieAsync(movie, cancellationToken);
        }
    }
}
