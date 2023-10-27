using CinemaBooking.Domain.Exceptions;
using CinemaBooking.Domain.Sessions;
using CinemaBooking.Domain.Sessions.Dtos;
using CinemaBooking.Infrustructure.Repositories;
using CinemaBooking.Infrustructure.Services;

namespace CinemaBooking.Application.Sessions
{
    public class ReservationService : IReservationService
    {
        private readonly IScheduledSessionRepository _sessionRepository;

        public ReservationService(IScheduledSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task ConfirmResevationAsync(Guid sessionId, Guid reservedSitId, CancellationToken cancellationToken = default)
        {
            var session = await _sessionRepository.GetScheduledSessionAsync(sessionId, cancellationToken);
            
            if (session == null)
            {
                throw new EntityNotFoundException($"Session {sessionId} not found");
            }

            session.ConfirmReservation(reservedSitId);

            await _sessionRepository.UpdateSchedulledSessionAsync(cancellationToken);
        }

        public async Task<IEnumerable<AvailableSession>> GetAvailableSessionsAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var availableSessions = new List<AvailableSession>();
            var sessions = await _sessionRepository.GetAvailableSessionsAsync(movieId, cancellationToken);
            foreach(var session in sessions)
            {
                var availableSits = CalculateAvailableSits(session);
                if(availableSits.Any())
                {
                    var availableSession = new AvailableSession
                    {
                        SessionId = session.Id,
                        StartDate = session.StartDate,
                        EndDate = session.EndDate,
                        Price = session.Price,
                        Movie = session.Movie,
                        AvailableSits = availableSits
                    };
                    availableSessions.Add(availableSession);
                }
            }
            return availableSessions;
        }

        public async Task<MovieTicket> GetReservationDetailsAsync(Guid sessionId, Guid reservationId, CancellationToken cancellationToken = default)
        {
            var session = await _sessionRepository.GetScheduledSessionAsync(sessionId, cancellationToken);

            if (session == null)
            {
                throw new EntityNotFoundException($"Session {sessionId} not found");
            }

            var resrevedSit = session.OrderedSits.FirstOrDefault(s => s.Id == reservationId);
            if (resrevedSit == null)
            {
                throw new EntityNotFoundException($"Session {sessionId} not found");
            }

            return new MovieTicket
            {
                SitNumber = resrevedSit.SitNumber,
                RowNumber = resrevedSit.RowNumber,
                StartDate = session.StartDate,
                CustomerName = resrevedSit.CustomerName,
                EndDate = session.EndDate,
                Movie = session.Movie,
                TotalCost = session.Price
            };
        }

        public async Task<Guid> ReserveSitInSessionAsync(ReservationDetails reservationDetails, CancellationToken cancellationToken = default)
        {
            var session = await _sessionRepository.GetScheduledSessionAsync(reservationDetails.SessionId, cancellationToken);
            if(session == null)
            {
                throw new EntityNotFoundException($"Session {reservationDetails.SessionId} not found");
            }

            if(session.OrderedSits.Any(s => s.RowNumber == reservationDetails.RowNumber && s.SitNumber == reservationDetails.SitNumber))
            {
                throw new SitReservationException($"Sit {reservationDetails.SitNumber} in reservationDetails.RowNumber row is unavailable");
            }

            var orderedSit = new OrderedSit(
                reservationDetails.RowNumber,
                reservationDetails.SitNumber,
                reservationDetails.CustomerName,
                reservationDetails.CustomerPhoneNumber);
            orderedSit.Reserve();
            session.OrderSit(orderedSit);
            await _sessionRepository.AddOrderedSitAsync(orderedSit, cancellationToken);
            await _sessionRepository.UpdateSchedulledSessionAsync(cancellationToken);
            return orderedSit.Id;
        }

        private IEnumerable<AvailableSit> CalculateAvailableSits(ScheduledSession session)
        {
            var availableSits = new List<AvailableSit>();
            var orderedSits = session.OrderedSits.Where(s => s.ReservedTill < DateTime.Now);

            for (ushort row = 1; row <= session.Theater.RowCount; row++)
            {
                for(ushort sit = 1; sit <= session.Theater.SitsInRow; sit++)
                {
                    if(session.OrderedSits.All(s => s.RowNumber != row && s.SitNumber != sit ))
                    {
                        availableSits.Add(new AvailableSit(row, sit));
                    }
                }
            }

            return availableSits;
        }
    }
}
