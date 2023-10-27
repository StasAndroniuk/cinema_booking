using AutoMapper;
using CinemaBooking.Contract.Api.Models;
using CinemaBooking.Contract.Api.Requests.Theaters;
using CinemaBooking.Contract.Api.Responses;
using CinemaBooking.Domain.Theaters.Dtos;
using CinemaBooking.Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Api.Controllers
{
    [ApiController]
    [Route("theaters")]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterService _theaterService;
        private readonly IMapper _mapper;

        public TheaterController(ITheaterService theaterService, IMapper mapper)
        {
            _theaterService = theaterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create new theater
        /// </summary>
        /// <param name="request"><see cref="CreateTheaterRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CreateTheaterResponse> CreateTheater(
            [FromBody] CreateTheaterRequest request,
            CancellationToken cancellationToken = default) =>
            new CreateTheaterResponse
            {
                Id = await _theaterService.CreateTheaterAsync(_mapper.Map<TheaterCreationDetails>(request), cancellationToken),
            };

        /// <summary>
        /// Updates existing theater
        /// </summary>
        /// <param name="theaterId">Id of theater.</param>
        /// <param name="request"><see cref="UpdateTheaterRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task UpdateTheater(
            [FromRoute]Guid Id,
            [FromBody]UpdateTheaterRequest request,
            CancellationToken cancellationToken = default) =>
            await _theaterService.UpdateTheaterAsync(Id, _mapper.Map<TheaterUpdateDetails>(request), cancellationToken);

        /// <summary>
        /// Delete existing theater.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeteleTheater([FromRoute] Guid Id, CancellationToken cancellationToken = default) =>
            await _theaterService.DeleteTheaterAsync(Id, cancellationToken);

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<GetTheaterResponse> GetTheater([FromRoute] Guid Id, CancellationToken cancellationToken = default) =>
            new GetTheaterResponse
            {
                Theater = _mapper.Map<Theater>(await _theaterService.GetTheaterAsync(Id, cancellationToken)),
            };
    }
}
