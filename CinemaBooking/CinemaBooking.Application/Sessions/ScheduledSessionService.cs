using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Sessions;
using CinemaBooking.Domain.Sessions.Dtos;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Infrustructure.Services;

namespace CinemaBooking.Application.Sessions
{
    public class ScheduledSessionService : IScheduledSessionService
    {
        private IScheduledSessionRepository _sessionRepository;
        private IMovieRepository _movieRepository;
        private ITheaterRepository _theaterRepository;

        public ScheduledSessionService(
            IScheduledSessionRepository sessionRepository,
            IMovieRepository movieRepository,
            ITheaterRepository theaterRepository)
        {
            _sessionRepository = sessionRepository;
            _movieRepository = movieRepository;
            _theaterRepository = theaterRepository;
        }

        public async Task<Guid> CreateSchedulledSessionAssync(SessionCreationDetails sessionCreationDetails, CancellationToken cancellationToken = default)
        {
            var theater = await _theaterRepository.GetTheaterAsync(sessionCreationDetails.TheaterId, cancellationToken);
            if(theater == null)
            {
                throw new EntityNotFoundException($"Theater with id: {sessionCreationDetails.TheaterId} not found");
            }

            var movie = await _movieRepository.GetMovieAsync(sessionCreationDetails.MovieId, cancellationToken);
            if(movie == null)
            {
                throw new EntityNotFoundException($"Movie with id: {sessionCreationDetails.MovieId} not found");
            }

            var existingSession = await _sessionRepository.TryFindSchedulledSessionAsync(
                sessionCreationDetails.MovieId,
                sessionCreationDetails.TheaterId,
                sessionCreationDetails.StartDate,
                sessionCreationDetails.EndDate,
                cancellationToken);
            if(existingSession != null)
            {
                throw new SessionInvalidOperationException($"Scheduled for movie {sessionCreationDetails.MovieId} isn't available for period {sessionCreationDetails.StartDate} and {sessionCreationDetails.EndDate}");
            }

            var newSession = new ScheduledSession(
                sessionCreationDetails.StartDate,
                sessionCreationDetails.EndDate,
                movie,
                theater,
                sessionCreationDetails.Price);

            await _sessionRepository.CreateSessionAsync(newSession, cancellationToken);
            return newSession.Id;
        }

        public async Task DeleteSessionAsync(Guid sessionId, CancellationToken cancellationToken = default)
        {
            var session = await _sessionRepository.GetScheduledSessionAsync(sessionId, cancellationToken);
            if(session == null)
            {
                throw new EntityNotFoundException($"Session {sessionId} not found");
            }

            if(session.StartDate <= DateTime.Now && session.EndDate >= DateTime.Now)
            {
                throw new SessionInvalidOperationException($"Can't remove pending session {sessionId}");
            }

            await _sessionRepository.DeleteSchedulledSession(session, cancellationToken);
        }

        public async Task<ScheduledSession?> GetScheduledSessionAsync(Guid sessionId, CancellationToken cancellationToken = default)
        {
            return await _sessionRepository.GetScheduledSessionAsync(sessionId, cancellationToken);
        }
    }
}
