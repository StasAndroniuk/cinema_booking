using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Theaters;
using CinemaBooking.Domain.Theaters.Dtos;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Infrustructure.Services;

namespace CinemaBooking.Application.Theaters
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepo;
        private readonly IScheduledSessionRepository _scheduledSessionRepository;
        public TheaterService(
            ITheaterRepository theaterRepository,
            IScheduledSessionRepository scheduledSessionRepository)
        {
            _theaterRepo = theaterRepository;
            _scheduledSessionRepository = scheduledSessionRepository;
        }

        public async Task<Guid> CreateTheaterAsync(TheaterCreationDetails theaterCreationDetails, CancellationToken cancellationToken = default)
        {
            var theater = new Theater(theaterCreationDetails.RowCount, theaterCreationDetails.SitsInRow);
            await _theaterRepo.CreateTheaterAsync(theater);
            return theater.Id;
        }

        public async Task DeleteTheaterAsync(Guid theaterId, CancellationToken cancellationToken = default)
        {
            var theater = await TryGetAvailableTheaterInternal(theaterId, cancellationToken);

            await _theaterRepo.DeleteTheaterAsync(theater, cancellationToken);
        }

        public async Task<Theater?> GetTheaterAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _theaterRepo.GetTheaterAsync(id, cancellationToken);
        }

        public async Task UpdateTheaterAsync(Guid theaterId, TheaterUpdateDetails theaterUpdateDetails, CancellationToken cancellationToken = default)
        {
            var theater = await TryGetAvailableTheaterInternal(theaterId, cancellationToken);
            theater.Update(theaterUpdateDetails);
            await _theaterRepo.UpdateTheaterAsync(theater, cancellationToken);
        }

        private async Task<Theater> TryGetAvailableTheaterInternal(Guid theaterId, CancellationToken cancellationToken = default)
        {
            var theater = await _theaterRepo.GetTheaterAsync(theaterId, cancellationToken);

            if (theater == null)
            {
                throw new EntityNotFoundException($"Theater {theaterId} not found");
            }

            var schedulledSession = await _scheduledSessionRepository.TryGetScheduledSessionAsync(theaterId, cancellationToken);
            if (schedulledSession != null)
            {
                throw new TheaterInvalidOperationException($"Theater {theaterId} is in use and can't be removed");
            }
            return theater;
        }
    }
}
