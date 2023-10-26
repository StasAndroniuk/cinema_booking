using AutoMapper;
using CinemaBooking.Contract.Api.Models;
using CinemaBooking.Contract.Api.Requests;
using CinemaBooking.Contract.Api.Responses;
using CinemaBooking.Domain.Movies.Dtos;
using CinemaBooking.Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Api.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns movie with specified Id.
        /// </summary>
        /// <param name="request"><see cref="GetMovieRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns><see cref="GetMovieResponse"/></returns>

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<GetMovieResponse> GetMovieAsync(
            [FromRoute] GetMovieRequest request,
            CancellationToken cancellationToken = default) =>
            new GetMovieResponse
            {
                Movie = _mapper.Map<Movie>(await _movieService.GetMovieAsync(request.Id, cancellationToken)),
            };

        /// <summary>
        /// Returns all created movies.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Collection of movies.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<GetMultipleMoviesResponse> GetMultipleMovies(CancellationToken cancellationToken = default) =>
            new GetMultipleMoviesResponse
            {
                Movies = (await _movieService.GetMoviesAsync(cancellationToken)).Select(m => _mapper.Map<Movie>(m)),
            };

        /// <summary>
        /// Create new movie.
        /// </summary>
        /// <param name="request"><see cref="CreateMovieRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CreateMovieResponse> CreateMovie(
            [FromBody] CreateMovieRequest request,
            CancellationToken cancellationToken = default) =>
            new CreateMovieResponse()
            {
                Id = await _movieService.CreateMovieAsync(_mapper.Map<MovieCreationDetails>(request), cancellationToken),
            };

        /// <summary>
        /// Updates existing movie.
        /// </summary>
        /// <param name="Id">Id of movie.</param>
        /// <param name="request"><see cref="UpdateMovieRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns><see cref="Task"/></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task UpdateMovie(
            [FromRoute] Guid Id,
            [FromBody] UpdateMovieRequest request,
            CancellationToken cancellationToken = default) =>
            await _movieService.UpdateMovieAsync(Id, _mapper.Map<MovieUpdateDetails>(request), cancellationToken);

        /// <summary>
        /// Deletes movie.
        /// </summary>
        /// <param name="request"><see cref="DeleteMovieRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task"/></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteMovie(
            [FromRoute] DeleteMovieRequest request,
            CancellationToken cancellationToken = default) =>
            await _movieService.DeleteMovieAsync(request.Id, cancellationToken);

    }
}
